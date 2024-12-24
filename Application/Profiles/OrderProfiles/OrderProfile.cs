using Application.Dtos.CatogeryDtos;
using Application.Dtos.OrderDto;
using AutoMapper;
using Domin.Entities.Order_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.OrderProfiles
{
	public class OrderProfile : Profile
	{
		public OrderProfile() 
		{ 
			CreateMap<Order,GetOrderDto>();
			CreateMap<CreateOrderDto, Order>();
			CreateMap<UpdateOrderDto, Order>();
		
		}
	}
}
