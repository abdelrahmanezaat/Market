using Application.Dtos.CategoryDtos;
using Application.Dtos.CatogeryDtos;
using Application.Profiles.Helpers;
using AutoMapper;
using Domin.Entities.Category_realted;
using Domin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.GategoryProfiles
{
	public class CategoryProfile: Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, GetCategoryDto>()
				 .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Constants.BASE_URL + src.ImageUrl));
			CreateMap<CreateCategoryDto, Category>()
				.AfterMap<SetImageAction<CreateCategoryDto, Category>>();
			CreateMap<UpdateCategoryDto, Category>();
		}
	}
}
