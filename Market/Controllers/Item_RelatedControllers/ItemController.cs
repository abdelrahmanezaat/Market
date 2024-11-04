using Application.Contract.IFeatures.IItem;
using Application.Dtos.ItemDtos;
using Domin.Entities.Item_realted;
using Market.Controllers.Common;

namespace Market.Controllers.Item_RelatedControllers
{
    public class ItemController : BaseController<Item, GetItemDto, CreateItemDto, UpdateItemDto>
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService) : base(itemService)
        {
            _itemService = itemService;
        }
    }
}

