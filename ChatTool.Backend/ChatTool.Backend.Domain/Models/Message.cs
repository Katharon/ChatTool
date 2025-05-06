using ChatTool.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTool.Backend.Domain.Models
{
    public class Message
    {
        public Message(byte[] content, MessageType messageType, Guid sender, Guid receiver, DateTime timestamp)
        {
            Content = content;
            MessageType = messageType;
            Sender = sender;
            Receiver = receiver;
            Timestamp = timestamp;
        }

        public byte[] Content { get; }

        public MessageType MessageType { get; }

        public Guid Sender { get; }

        public Guid Receiver { get; }

        public DateTime Timestamp { get; }
    }
}
