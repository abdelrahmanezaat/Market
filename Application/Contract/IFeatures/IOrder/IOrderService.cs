using Application.Dtos.OrderDto;
using Domin.Entities.Order_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IFeatures.IOrder
{
	public interface IOrderService:IBaseService<Order,GetOrderDto,CreateOrderDto,UpdateOrderDto>
	{
		Task<GetOrderDto> CreateOrder(CreateOrderDto order,Guid UserId);
	}
}
