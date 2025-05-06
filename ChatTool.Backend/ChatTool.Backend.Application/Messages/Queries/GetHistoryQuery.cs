namespace ChatTool.Backend.Application.Messages.Queries
{
    using ChatTool.Backend.Domain.Models;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GetHistoryQuery : IRequest<IEnumerable<Message>>
    {
        public GetHistoryQuery(Guid chatId, int page, int size, Guid requestingUserId)
        {
            this.ChatId = chatId;
            this.Page = page;
            this.Size = size;
            this.RequestingUserId = requestingUserId;
        }

        public Guid ChatId { get; }
        public int Page { get; }
        public int Size { get; }
        public Guid RequestingUserId { get; }
    }
}
