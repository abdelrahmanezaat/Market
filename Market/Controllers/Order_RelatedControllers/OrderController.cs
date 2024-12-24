using Application.Contract.IFeatures.IOrder;
using Application.Dtos.CatogeryDtos;
using Application.Dtos.OrderDto;
using Domin.Entities.Order_realted;
using Market.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers.Order_RelatedControllers
{
	[Authorize]
	//RT2EBJPs1QKtbpk6PDy5fveliXzo22UiwMvQnCPfIsA=
	public class OrderController: BaseController<Order,GetCategoryDto,CreateOrderDto,UpdateOrderDto>
	{
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService):base(orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("CreateOrderAsync")]
		public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderDto model)
		{
			var userID = HttpContext.User.FindFirst("uid").Value;
			var result = await _orderService.CreateOrder(model, Guid.Parse(userID));
			return Ok(result);
		}


	}
}
