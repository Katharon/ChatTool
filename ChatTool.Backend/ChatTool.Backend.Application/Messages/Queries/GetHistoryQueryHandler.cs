namespace ChatTool.Backend.Application.Messages.Queries
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository repository;

        public GetHistoryQueryHandler(IMessageRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Message>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            // Für echte Apps: Paging + Filterung + Mapping auf DTOs
            var messages = await this.repository.GetBetweenUsersAsync(request.RequestingUserId, request.ChatId);
            return messages;
        }
    }
}
