//namespace ChatTool.WebApi.Controllers
//{
//    using ChatTool.Application.Messages.Commands;
//    using ChatTool.Application.Messages.DTOs;
//    using ChatTool.Application.Messages.Queries;
//    using ChatTool.Application.Users.Interfaces;
//    using MediatR;
//    using Microsoft.AspNetCore.Mvc;

//    [Route("api/[controller]")]
//    [ApiController]
//    public class MessagesControllerMediatR : ControllerBase
//    {
//        private readonly IMediator mediator;

//        private readonly IUserService user;

//        public MessagesControllerMediatR(IMediator mediator, IUserService user)
//        {
//            this.mediator = mediator;
//            this.user = user;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetHistory(Guid chatId, [FromQuery] int page = 1, [FromQuery] int size = 50)
//        {
//            var messages = await this.mediator.Send(new GetHistoryQuery(chatId, page, size, this.user.Id));
//            return Ok(messages);
//        }

//        [HttpPost]
//        public async Task<IActionResult> SendMessage(Guid chatId, [FromBody] SendMessageDto dto)
//        {
//            await this.mediator.Send(new SendMessageCommand(chatId, dto.Content, dto.Type, this.user.Id));
//            return Accepted();
//        }
//    }
//}
