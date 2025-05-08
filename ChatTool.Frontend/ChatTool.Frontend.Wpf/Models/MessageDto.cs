namespace ChatTool.Frontend.Wpf.Models
{
    public class MessageDto
    {
        public MessageDto(string content, Guid sender, Guid receiver, DateTime? timestamp)
        {
            this.Content = content;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Timestamp = timestamp;
        }

        public string Content { get; }
        public Guid Sender { get; }
        public Guid Receiver { get; }
        public DateTime? Timestamp { get; }
    }
}