using Domin.Entities.Category_realted;
using Domin.Entities.Commin;
using Domin.Entities.Item_realted;
using Domin.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.Order_realted
{
	public class Order:BaseEntity
	{
		public int Quantity { get; set; }
		public int TotalPrice { get; set; }
		public Guid UserId{ get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual UserAccount UserAccount { get; set; }
		public Guid ItemId{ get; set; }
		[ForeignKey(nameof(ItemId))]
		public virtual Item Item {  get; set; }
		public string Address { get; set; }
		public string ArrivalDate { get; set; }
		public string PhoneNumber { get; set; }
	}
}
