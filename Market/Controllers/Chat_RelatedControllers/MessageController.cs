using Application.Contract.IFeatures.IChat;
using Application.Dtos.ChatDtos_realted.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers.Chat_RelatedControllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	//[Authorize]
	public class MessageController : ControllerBase
	{
		private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
         _messageService   = messageService;
        }
		[HttpGet("GetAllMessage{ChatId}")]
		public async Task<IActionResult> GetAllMessage(Guid ChatId)
		{
			var result = await _messageService.GetAllMessage(ChatId);
			if (result != null)
				return Ok(result);
			else return BadRequest();

		}
		[HttpPost("SendMessage")]
		public async Task<IActionResult> SendMessage([FromBody] CreateMessageDto model)
		{
			var result = await _messageService.SendMessage(model);
			if (result != null) 
			return Ok(result);
			else return BadRequest();
		}

	}
}
