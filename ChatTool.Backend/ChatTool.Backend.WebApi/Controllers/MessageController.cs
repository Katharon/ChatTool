namespace ChatTool.Backend.WebApi.Controllers
{
    using ChatTool.Backend.Application.Messages.DTOs;
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain;
    using ChatTool.Backend.Domain.Enums;
    using ChatTool.Backend.Domain.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        private readonly ILogger<MessageController> logger;

        public MessageController(IMessageService messageService, ILogger<MessageController> logger)
        {
            this.messageService = messageService;
            this.logger = logger;
        }

        [HttpPost("GetMessages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages([FromBody] HistoryRequestDto request)
        {
            IEnumerable<Message> messages = await this.messageService.GetConversationAsync(request.UserA, request.UserB);

            if (!messages.Any())
            {
                return NotFound();
            }

            return this.Ok(messages);
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto request)
        {
            var content = request.Content;
            var type = request.Type;
            var sender = request.Sender;
            var receiver = request.Receiver;

            await this.messageService.SendMessageAsync(content, type, sender, receiver);

            return this.Accepted();
        }
    }
}
