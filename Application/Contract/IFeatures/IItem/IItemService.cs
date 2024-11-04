using Application.Dtos.ItemDtos;
using Domin.Entities.Item_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IFeatures.IItem
{
	public interface IItemService:IBaseService<Item,GetItemDto,CreateItemDto,UpdateItemDto>
	{
	}
}
