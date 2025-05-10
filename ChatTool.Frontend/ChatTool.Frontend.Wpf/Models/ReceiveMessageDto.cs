namespace ChatTool.Frontend.Wpf.Models
{
    using System;
    using System.Text;

    public class ReceiveMessageDto
    {
        public ReceiveMessageDto(Guid id, string publicKeyBase64, byte[] content, MessageType type, Guid sender, Guid receiver, DateTime timestamp)
        {
            this.Id = id;
            this.PublicKeyBase64 = publicKeyBase64;
            this.Content = content;
            this.Type = type;
            this.Sender = sender;
            this.Receiver = receiver;
            this.Timestamp = timestamp;
        }

        public Guid Id { get; set; }
        public string PublicKeyBase64 { get; }
        public byte[] Content { get; }
        public MessageType Type { get; }
        public Guid Sender { get; }
        public Guid Receiver { get; }
        public DateTime Timestamp { get; }
        public string Text => Encoding.UTF8.GetString(this.Content);
    }
}