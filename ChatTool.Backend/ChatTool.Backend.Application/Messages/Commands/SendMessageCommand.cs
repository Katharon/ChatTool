namespace ChatTool.Backend.Application.Messages.Commands
{
    using ChatTool.Backend.Domain;
    using ChatTool.Backend.Domain.Enums;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SendMessageCommand : IRequest<Unit>
    {
        public SendMessageCommand(Guid chatId, byte[] content, MessageType type, Guid senderId)
        {
            ChatId = chatId;
            Content = content;
            Type = type;
            SenderId = senderId;
        }

        public Guid ChatId { get; }
        public byte[] Content { get; }
        public MessageType Type { get; }
        public Guid SenderId { get; }
    }
}
