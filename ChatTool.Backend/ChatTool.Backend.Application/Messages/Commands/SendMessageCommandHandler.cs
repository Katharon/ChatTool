namespace ChatTool.Backend.Application.Messages.Commands
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, Unit>
    {
        private readonly IMessageRepository repository;

        public SendMessageCommandHandler(IMessageRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message(
                request.Content,
                request.Type,
                request.SenderId,
                request.ChatId,
                DateTime.UtcNow
            );

            await repository.AddMessageAsync(message);
            return Unit.Value;
        }
    }
}
