namespace ChatTool.Backend.Application.Messages.Interfaces
{
    using ChatTool.Backend.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IMessageRepository
    {
        Task AddMessageAsync(Message message);

        Task<IEnumerable<Message>> GetBetweenUsersAsync(Guid userA, Guid userB);

        Task<IEnumerable<Message>> GetReceivedMessagesAsync(Guid receiverId);
    }
}
