namespace ChatTool.Backend.Persistence.Repositories
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain.Models;
    using ChatTool.Backend.Persistence.Context;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class MessageRepository : IMessageRepository
    {
        private readonly MessengerDbContext dbContext;

        public MessageRepository(MessengerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddMessageAsync(Message message)
        {
            this.dbContext.Messages.Add(message);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetBetweenUsersAsync(Guid userA, Guid userB)
        {
            return await this.dbContext.Messages
                .Where(m =>
                    (m.Sender == userA && m.Receiver == userB) ||
                    (m.Sender == userB && m.Receiver == userA))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<Message>> GetReceivedMessagesAsync(Guid receiverId)
        {
            return await this.dbContext.Messages
                .Where(m => m.Receiver == receiverId)
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync();
        }
    }
}
