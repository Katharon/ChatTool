namespace ChatTool.Frontend.Wpf.Models
{
    public class SendMessageDto
    {
        public SendMessageDto(byte[] content, MessageType type, Guid sender, Guid receiver)
        {
            this.Content = content;
            this.Type = type;
            this.Sender = sender;
            this.Receiver = receiver;
        }

        public byte[] Content { get; }
        public MessageType Type { get; }
        public Guid Sender { get; }
        public Guid Receiver { get; }
    }
}