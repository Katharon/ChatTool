namespace ChatTool.Backend.Application.Messages.Interfaces
{
    using ChatTool.Backend.Domain.Models;
    using ChatTool.Backend.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ChatTool.Backend.Domain.Enums;

    public interface IMessageService
    {
        Task SendMessageAsync(byte[] content, MessageType type, Guid sender, Guid receiver);

        Task<IEnumerable<Message>> GetConversationAsync(Guid userA, Guid userB);
    }
}
