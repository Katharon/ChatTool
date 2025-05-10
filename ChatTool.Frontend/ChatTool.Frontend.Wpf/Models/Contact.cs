namespace ChatTool.Frontend.Wpf.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Media;

    public class Contact : INotifyPropertyChanged
    {
        public Contact(Guid id, string publicKeyBase64, string userName, string lastMessage, ImageSource profileImage, DateTime lastSeenTimestamp, DateTime lastMessageTimestamp)
        {
            this.Id = id;
            this.PublicKeyBase64 = publicKeyBase64;
            this.UserName = userName;
            this.LastMessage = lastMessage;
            this.ProfileImage = profileImage;
            this.LastSeenTimestamp = lastSeenTimestamp;
            this.LastMessageTimestamp = lastMessageTimestamp;
        }

        public Guid Id { get; }
        public string PublicKeyBase64 { get; }
        public string UserName { get; }
        public string LastMessage
        {
            get => field;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                field = value;
                this.OnPropertyChanged(nameof(LastMessage));
            }
        }
        public ImageSource ProfileImage { get; }
        public DateTime LastSeenTimestamp { get; }
        public DateTime LastMessageTimestamp
        {
            get => field;
            set
            {
                field = value;
                this.OnPropertyChanged(nameof(LastMessageTimestamp));
            }
        }
        public ObservableCollection<ReceiveMessageDto> Messages { get; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
