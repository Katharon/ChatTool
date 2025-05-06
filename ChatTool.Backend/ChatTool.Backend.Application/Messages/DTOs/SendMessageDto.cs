namespace ChatTool.Backend.Application.Messages.DTOs
{
    using ChatTool.Backend.Domain;
    using ChatTool.Backend.Domain.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SendMessageDto
    {
        public byte[] Content { get; set; } = default!;

        public MessageType Type { get; set; }
    }
}
