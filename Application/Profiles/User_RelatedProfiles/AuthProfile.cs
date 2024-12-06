using Application.Dtos.UserDtos.AuthDtos;
using AutoMapper;
using Domin.Entities.UserEntities;
using Domin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.User_RelatedProfiles
{
	public class AuthProfile : Profile
	{
		public AuthProfile()
		{
			CreateMap<RegisterDto, UserAccount>();

			CreateMap<UserAccount, AuthDto>()
				.ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => Constants.BASE_URL + src.ProfilePictureUrl))
				
				.ForMember(dest => dest.RefreshToken, opt =>
					opt.MapFrom(src => src.UserSessions.FirstOrDefault(x => !x.IsDeleted).RefreshToken))
				.ForMember(dest => dest.RefreshTokenExpirationDate, opt =>
					opt.MapFrom(src => src.UserSessions.FirstOrDefault(x => !x.IsDeleted).RefreshTokenExpirationDate))
				.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(x => x.Role.Name)));
		}
	}
}
