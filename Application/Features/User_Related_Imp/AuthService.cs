using Application.Contract.IInfrastructure;
using Application.Contract.IRepositories.ICommon;
using Application.Contract.IUser;
using Application.Dtos.UserDtos.AuthDtos;
using Application.Exceptions;
using AutoMapper;
using Domin.Entities.UserEntities;
using Domin.Utils;
using Domin.Utils.UserConstants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User_Related_Imp
{
	public class AuthService : IAuthService
	{
		private readonly IPasswordHashService _passwordHashService;
		private readonly IJwtService _jwtService;
		private readonly IMapper _mapper;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IBaseRepository<UserAccount> _repository;
        public AuthService(IPasswordHashService passwordHashService,IJwtService jwtService,IMapper mapper,IUnitOfWork unitOfWork)
        {
			_passwordHashService = passwordHashService;
			_jwtService = jwtService;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_repository = _unitOfWork.GetRepository<UserAccount>();
			
		}
        public async Task<AuthDto> Login(LoginDto loginDto)
		{
			
			

			var user = await _repository.FirstOrDefaultAsync(x=>x.Email==loginDto.Email,source=>source.Include(x=>x.UserSessions));

			if (user == null || !_passwordHashService.Verify(user.PasswordHash, loginDto.Password))
				throw new UnauthenticatedException();

			return await _jwtService.CreateAuthDto(user);
		}

		public async Task<AuthDto> Register(RegisterDto registerDto)
		{
			if (await _repository.Exists(x => x.Email == registerDto.Email && !x.IsDeleted))
				throw new AlreadyExistsException("Email");
			var user = _mapper.Map<UserAccount>(registerDto);
			user.PasswordHash = _passwordHashService.Hash(registerDto.Password);
			

			user.UserRoles.Add(new UserRole { UserAccount = user, RoleId = RoleConstValues.User });
			var refreshToken = _jwtService.GenerateRefreshToken();
			user.UserSessions.Add(new UserSession { RefreshToken = refreshToken, UserAccount = user, RefreshTokenExpirationDate = DateTimeOffset.Now.AddDays(7) });
			await _repository.AddAsync(user); 
			await _unitOfWork.SaveChangesAsync();
			
			return await _jwtService.CreateAuthDto(user);
			
			

		}
		public async Task<AuthDto> RefreshToken(RefreshTokenDto refreshTokenDto)
		{
			var user = await _jwtService.GetUserByRefreshTokenAsync(refreshTokenDto.RefreshToken,
				include: source => source
				.Include(x => x.UserSessions)
				.Include(x => x.UserRoles)
				.ThenInclude(x => x.Role)
			) ?? throw new UnauthenticatedException();

			return await _jwtService.CreateAuthDto(user);
		}
	}
}
