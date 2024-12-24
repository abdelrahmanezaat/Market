using Application.Contract.IFeatures.IOrder;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.OrderDto;
using Application.Features.Common;
using AutoMapper;
using Domin.Entities.Order_realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order_Related
{
	public class OrderService:BaseService<Order,GetOrderDto,CreateOrderDto,UpdateOrderDto>,IOrderService
	{
		public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)

		{
			
            
        }
		public async Task<GetOrderDto> CreateOrder(CreateOrderDto Model,Guid UserId)
		{
		
			Model.UserId=UserId;	
			var order = _mapper.Map<Order>(Model);
			await _repository.AddAsync(order);
			await _unitOfWork.SaveChangesAsync();
			var result=_mapper.Map<GetOrderDto>(order);
			return result;

		}
    }
}
