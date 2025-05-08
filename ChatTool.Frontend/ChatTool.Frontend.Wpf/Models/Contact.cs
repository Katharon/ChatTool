namespace ChatTool.Frontend.Wpf.Models
{
    using System;
    using System.Windows.Media;

    class Contact
    {
        public Contact(Guid id, string userName, string lastMessage, ImageSource profileImage, DateTime lastSeenTimestamp, DateTime lastMessageTimestamp)
        {
            this.Id = id;
            this.UserName = userName;
            this.LastMessage = lastMessage;
            this.ProfileImage = profileImage;
            this.LastSeenTimestamp = lastSeenTimestamp;
            this.LastMessageTimestamp = lastMessageTimestamp;
        }

        public Guid Id { get; }
        public string UserName { get; }
        public string LastMessage { get; }
        public ImageSource ProfileImage { get; }
        public DateTime LastSeenTimestamp { get; }
        public DateTime LastMessageTimestamp { get; }
        public List<ReceiveMessageDto> Messages { get; } = [];
    }
}
