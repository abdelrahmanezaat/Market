using Application.Contract.IInfrastructure;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.UserDtos.AuthDtos;
using Application.Exceptions;
using AutoMapper;
using Domin.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public class JwtService : IJwtService
	{
		private readonly JwtSetting _jwtSetting;
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public JwtService(IOptions<JwtSetting> jwtSetting,IUnitOfWork unitOfWork, IMapper mapper)
		{
			_jwtSetting = jwtSetting.Value;
			
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<(string, DateTime)> GenerateAccessToken(UserAccount user)
		{
			var userRoles = await _unitOfWork.GetRepository<UserRole>()
			   .FindAsync(x => !x.IsDeleted && user.Id == x.UserId,
			   include: source => source.Include(x => x.Role));

			var roles = userRoles.Select(x => x.Role.Name);

			var roleClaims = new List<Claim>();

			foreach (var role in roles)
			{
				roleClaims.Add(new Claim("roles", role));
			}

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim("uid", user.Id.ToString())
			}
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwtSetting.Issuer,
				audience: _jwtSetting.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_jwtSetting.DurationInMinutes),
				signingCredentials: signingCredentials
			);

			var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			var expiresOn = jwtSecurityToken.ValidTo;

			return (token, expiresOn);
		}

		public string GenerateRefreshToken()
		{
			var randomNumber = new byte[32];

			using var generator = new RNGCryptoServiceProvider();

			generator.GetBytes(randomNumber);

			return Convert.ToBase64String(randomNumber);
		}

		public async Task<UserAccount> GetUserByRefreshTokenAsync(string refreshToken, Func<IQueryable<UserAccount>, IIncludableQueryable<UserAccount, object>>? include = null)
		{
			if (refreshToken == null)
				throw new BadRequestException("Refreshtoken is required!");

			var user = await _unitOfWork.GetRepository<UserAccount>()
				.FirstOrDefaultAsync(u => !u.IsDeleted && u.UserSessions
					.Any(r => r.RefreshToken == refreshToken && !r.IsDeleted), include)
				?? throw new EntityNotFoundException("المستخدم غير موجود");

			return user;
		}
		public async Task<AuthDto> CreateAuthDto(UserAccount user)
        {
            var token = await GenerateAccessToken(user);
			var session = user.UserSessions.FirstOrDefault(x => !x.IsDeleted) ?? throw new EntityNotFoundException();

			if (session.RefreshTokenExpirationDate < DateTime.Now)
            {
                session.RefreshToken = GenerateRefreshToken();
                session.RefreshTokenExpirationDate = DateTimeOffset.Now.AddDays(7);

                await _unitOfWork.SaveChangesAsync();

            }

            var authDto = _mapper.Map<AuthDto>(user);

            authDto.AccessToken = token.Item1;
            authDto.AccessTokenExpirationDate = token.Item2;
            return authDto;
        }
	}
}
