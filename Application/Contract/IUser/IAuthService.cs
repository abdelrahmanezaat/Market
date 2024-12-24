using Application.Dtos.UserDtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IUser
{
	public interface IAuthService
	{
		Task<AuthDto> Register(RegisterDto registerDto);
		Task<AuthDto> Login(LoginDto loginDto);
		Task<AuthDto> RefreshToken(RefreshTokenDto refreshTokenDto);

	}
}
