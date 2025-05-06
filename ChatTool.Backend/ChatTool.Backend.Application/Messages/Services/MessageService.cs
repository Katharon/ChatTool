namespace ChatTool.Backend.Application.Messages.Services
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain;
    using ChatTool.Backend.Domain.Enums;
    using ChatTool.Backend.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public async Task SendMessageAsync(byte[] content, MessageType type, Guid sender, Guid receiver)
        {
            var message = new Message(content, type, sender, receiver, DateTime.UtcNow);

            if (content is null || content.Length == 0)
            {
                throw new ArgumentException("Message content must not be empty.");
            }

            await messageRepository.AddMessageAsync(message);
        }

        public async Task<IEnumerable<Message>> GetConversationAsync(Guid userA, Guid userB)
        {
            return await messageRepository.GetBetweenUsersAsync(userA, userB);
        }
    }
}
