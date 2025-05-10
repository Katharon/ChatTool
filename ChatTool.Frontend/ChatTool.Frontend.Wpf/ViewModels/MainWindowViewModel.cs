namespace ChatTool.Frontend.Wpf.ViewModels
{
    using ChatTool.Frontend.Wpf.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7118")
        };

        public MainWindowViewModel()
        {
            this.LoadUsers();
            this.LoadMessages();

            Task.Run(() =>
            {
                this.LoadMessagesForChat();
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public event EventHandler? MessageReceived;

        public Guid SelfId { get; set; }
        public string PrivateKey { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public ObservableCollection<Contact> Contacts { get; set; } = [];

        public Contact? SelectedContact { get; set; }

        public ICommand SendMessageCommand
        {
            get
            {
                return new ParametrizedCommand<Contact>(
                    execute: contact => SendMessage(this.MessageText),
                    canExecute: contact => contact != null
                );
            }
        }

        public async void LoadUsers()
        {
            var response = await this.httpClient.GetAsync("/api/User/GetAllUsers");
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<UserDto>>();
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        var id = user.Id;
                        var publicKeyBase64 = user.PublicKeyBase64;
                        var userName = user.UserName;
                        var lastMessage = string.Empty;
                        var profileImage = new BitmapImage(new Uri("pack://application:,,,/ChatTool.Frontend.Wpf;component/Resources/Images/Bubu.png"));
                        var lastSeenTimestamp = DateTime.Now;
                        var lastMessageTimestamp = DateTime.Now;

                        if (user.Id != this.SelfId)
                        {
                            var contact = new Contact(id, publicKeyBase64, userName, lastMessage, profileImage, lastSeenTimestamp, lastMessageTimestamp);
                            this.Contacts.Add(contact);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }

        public async void LoadMessages()
        {
            foreach (Contact contact in this.Contacts)
            {
                var requestBody = new HistoryRequestDto(this.SelfId, contact.Id);

                var response = await this.httpClient.PostAsJsonAsync("/api/Message/GetMessages", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    var messages = await response.Content.ReadFromJsonAsync<List<ReceiveMessageDto>>();
                    if (messages != null)
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            // PrivateKey importieren
                            using RSA rsa = RSA.Create();
                            byte[] privateKeyBytes = Convert.FromBase64String(this.PrivateKey);
                            rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);

                            contact.Messages.Clear();
                            foreach (var message in messages)
                            {
                                // Entschlüsseln
                                byte[] decryptedBytes = rsa.Decrypt(message.Content, RSAEncryptionPadding.OaepSHA256);
                                string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                                // Nachricht ersetzen
                                var decryptedMessage = new ReceiveMessageDto(
                                    message.Id,
                                    contact.PublicKeyBase64,
                                    decryptedBytes,
                                    message.Type,
                                    message.Sender,
                                    message.Receiver,
                                    message.Timestamp
                                );

                                contact.Messages.Add(decryptedMessage);
                                contact.LastMessage = Encoding.UTF8.GetString(decryptedBytes);
                                contact.LastMessageTimestamp = message.Timestamp;
                            }
                        });

                        this.MessageReceived?.Invoke(this, EventArgs.Empty);
                        this.OnPropertyChanged(nameof(contact));
                    }
                }
            }
        }

        public async void LoadMessagesForChat()
        {
            while (true)
            {
                if (this.SelectedContact is not null)
                {
                    var requestBody = new HistoryRequestDto(this.SelfId, this.SelectedContact.Id);

                    var response = await this.httpClient.PostAsJsonAsync("/api/Message/GetMessages", requestBody);
                    if (response.IsSuccessStatusCode)
                    {
                        var messages = await response.Content.ReadFromJsonAsync<List<ReceiveMessageDto>>();
                        if (messages != null)
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                // PrivateKey importieren
                                using RSA rsa = RSA.Create();
                                byte[] privateKeyBytes = Convert.FromBase64String(this.PrivateKey);
                                rsa.ImportPkcs8PrivateKey(privateKeyBytes, out _);

                                var existingMessages = this.SelectedContact.Messages;
                                foreach (var message in messages)
                                {
                                    bool exists = existingMessages.Any(m => m.Id == message.Id);
                                    if (!exists)
                                    {
                                        // Entschlüsseln
                                        byte[] decryptedBytes = rsa.Decrypt(message.Content, RSAEncryptionPadding.OaepSHA256);
                                        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                                        // Nachricht ersetzen
                                        var decryptedMessage = new ReceiveMessageDto(
                                            message.Id,
                                            this.SelectedContact.PublicKeyBase64,
                                            decryptedBytes,
                                            message.Type,
                                            message.Sender,
                                            message.Receiver,
                                            message.Timestamp
                                        );

                                        existingMessages.Add(decryptedMessage);
                                        this.SelectedContact.LastMessage = Encoding.UTF8.GetString(decryptedBytes);
                                        this.SelectedContact.LastMessageTimestamp = message.Timestamp;
                                        this.MessageReceived?.Invoke(this, EventArgs.Empty);

                                        // OLD WITHOUT RSA
                                        // existingMessages.Add(message);
                                        // this.SelectedContact.LastMessage = Encoding.UTF8.GetString(message.Content);
                                        // this.SelectedContact.LastMessageTimestamp = message.Timestamp;
                                        // this.MessageReceived?.Invoke(this, EventArgs.Empty);
                                    }
                                }
                            });

                            this.OnPropertyChanged(nameof(this.SelectedContact));
                        }
                    }

                    await Task.Delay(500);
                }
            }
        }

        public async void SendMessage(string text)
        {
            string messageText = this.MessageText;
            this.MessageText = string.Empty;
            this.OnPropertyChanged(nameof(MessageText));

            if (string.IsNullOrWhiteSpace(messageText))
            {
                return;
            }
            if (this.SelectedContact == null)
            {
                return;
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(text);

            using RSA rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(this.SelectedContact.PublicKeyBase64), out _);
            byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.OaepSHA256);

            var sendMessageDto = new SendMessageDto(encryptedBytes, MessageType.Text, this.SelfId, this.SelectedContact.Id);
            var response = await this.httpClient.PostAsJsonAsync("/api/Message/SendMessage", sendMessageDto);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
