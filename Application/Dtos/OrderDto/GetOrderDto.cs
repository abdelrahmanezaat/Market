using Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.OrderDto
{
	public class GetOrderDto : BaseGetDto
	{
		public int Quantity { get; set; }
		public int TotalPrice { get; set; }
		public Guid UserId { get; set; }
		public Guid ItemId { get; set; }
		public string Address { get; set; }
		public string ArrivalDate { get; set; }
		public string PhoneNumber { get; set; }
	}
}
