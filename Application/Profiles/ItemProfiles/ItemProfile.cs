using Application.Dtos.ItemDtos;
using Application.Profiles.Helpers;
using AutoMapper;
using Domin.Entities.Item_realted;
using Domin.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.ItemProfiles
{
	public class ItemProfile:Profile
	{
		public ItemProfile() 
		{ 
			CreateMap<Item, GetItemDto>()
				 .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => Constants.BASE_URL + src.ImageUrl));
			CreateMap<CreateItemDto, Item>()
				.AfterMap<SetImageAction<CreateItemDto, Item>>();
			CreateMap<UpdateItemDto, Item>();
		}
	}
}
