using Application.Contract.IUser;
using Application.Dtos.UserDtos.AuthDtos;
using Market.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers.User_RelatedControllers
{
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _authService.Register(registerDto);

			return Ok(new { message = result });
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			var result = await _authService.Login(loginDto);

			return Ok(result);
		}

	}
}
