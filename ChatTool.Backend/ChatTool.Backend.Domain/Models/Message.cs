using ChatTool.Backend.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatTool.Backend.Domain.Models
{
    public class Message : Entity
    {
        public Message(byte[] content, MessageType messageType, Guid sender, Guid receiver, DateTime timestamp)
        {
            Content = content;
            MessageType = messageType;
            Sender = sender;
            Receiver = receiver;
            Timestamp = timestamp;
        }

        public byte[] Content { get; set; }

        public MessageType MessageType { get; set; }

        public Guid Sender { get; set; }

        public Guid Receiver { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
