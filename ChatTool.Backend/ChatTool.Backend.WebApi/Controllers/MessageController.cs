namespace ChatTool.Backend.WebApi.Controllers
{
    using ChatTool.Backend.Application.Messages.Interfaces;
    using ChatTool.Backend.Domain;
    using ChatTool.Backend.Domain.Enums;
    using ChatTool.Backend.Domain.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetHistory(Guid userA, Guid userB)
        {
            IEnumerable<Message> messages = await this.messageService.GetConversationAsync(userA, userB);

            if (!messages.Any())
            {
                return NotFound();
            }

            return this.Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(byte[] content, MessageType type, Guid sender, Guid receiver)
        {
            await this.messageService.SendMessageAsync(content, type, sender, receiver);

            return this.Accepted();
        }
    }
}
