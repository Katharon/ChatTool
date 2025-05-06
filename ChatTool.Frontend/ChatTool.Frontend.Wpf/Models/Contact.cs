namespace ChatTool.Frontend.Wpf.Models
{
    using System;
    using System.Windows.Media;

    class Contact
    {
        public Contact(string name, string lastMessage, ImageSource profileImage, DateTime lastSeenTimestamp, DateTime lastMessageTimestamp)
        {
            this.Name = name;
            this.LastMessage = lastMessage;
            this.ProfileImage = profileImage;
            this.LastSeenTimestamp = lastSeenTimestamp;
            this.LastMessageTimestamp = lastMessageTimestamp;
        }

        public string Name { get; set; }
        public string LastMessage { get; set; }
        public ImageSource ProfileImage { get; set; }
        public DateTime LastSeenTimestamp { get; set; }
        public DateTime LastMessageTimestamp { get; set; }
    }
}
