namespace ChatTool.Frontend.Wpf.ViewModels
{
    using ChatTool.Backend.Application.Users.DTOs;
    using ChatTool.Frontend.Wpf.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text;
    using System.Text.Unicode;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;

    class MainWindowViewModel
    {
        private readonly HttpClient httpClient = new()
        {
            BaseAddress = new Uri("https://localhost:7118")
        };

        public MainWindowViewModel()
        {
            this.LoadUsers();

            Task.Run(() =>
            {
                this.LoadMessages();
            });
        }

        public Guid SelfId { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public ObservableCollection<Contact> Contacts { get; set; } = new ();

        public Contact? SelectedContact { get; set; }

        public ICommand SendMessageCommand
        {
            get
            {
                return new ParametrizedCommand<Contact>(
                    execute: contact => SendMessage(contact),
                    canExecute: contact => contact != null
                );
            }
        }

        private async void LoadUsers()
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
                        var userName = user.UserName;
                        var lastMessage = user.Id.ToString();
                        var profileImage = new BitmapImage(new Uri("pack://application:,,,/ChatTool.Frontend.Wpf;component/Resources/Images/Bubu.png"));
                        var lastSeenTimestamp = DateTime.Now;
                        var lastMessageTimestamp = DateTime.Now;

                        var contact = new Contact(id, userName, lastMessage, profileImage, lastSeenTimestamp, lastMessageTimestamp);
                        this.Contacts.Add(contact);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }

        private async void LoadMessages()
        {
            while (true)
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
                            contact.Messages.Clear();
                            foreach (var message in messages)
                            {
                                contact.Messages.Add(message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Fehler: {response.StatusCode}");
                    }
                }

                Thread.Sleep(500);
            }
        }

        public async void SendMessage(Contact contact)
        {
            string messageText = this.MessageText;
            if (string.IsNullOrWhiteSpace(messageText))
            {
                return;
            }

            byte[] messageData = Encoding.UTF8.GetBytes(messageText);
            var sendMessageDto = new SendMessageDto(messageData, MessageType.Text, this.SelfId, contact.Id);

            var response = await this.httpClient.PostAsJsonAsync("/api/Message/SendMessage", sendMessageDto);
            if (response.IsSuccessStatusCode)
            {
                //MessageBox.Show("Geschafft.");
            }
            else
            {
                MessageBox.Show($"Fehler: {response.StatusCode}");
            }
        }
    }
}
