using Application.Dtos.UserDtos.AuthDtos;
using Domin.Entities.UserEntities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IInfrastructure
{
	public interface IJwtService
	{
		Task<(string, DateTime)> GenerateAccessToken(UserAccount user);
		string GenerateRefreshToken();
		Task<UserAccount> GetUserByRefreshTokenAsync(string refreshToken, Func<IQueryable<UserAccount>, IIncludableQueryable<UserAccount, object>>? include = null);
		Task<AuthDto> CreateAuthDto(UserAccount user);
	}
}
