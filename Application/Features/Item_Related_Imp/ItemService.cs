using Application.Contract.IFeatures.IItem;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.ItemDtos;
using Application.Features.Common;
using AutoMapper;
using Domin.Entities.Item_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item_Related_Imp
{
	public class ItemService:BaseService<Item, GetItemDto, CreateItemDto, UpdateItemDto>,IItemService
	{
		public ItemService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}
	}
}
