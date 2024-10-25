using Domin.Entities.Commin;
using Domin.Entities.Item_realted;
using Domin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domin.Entities.Category_realted
{
	public class Category:BaseLookupEntity
	{
		public string ImageUrl { get; set; }
		public virtual ICollection<Item> Items { get; set; }
	}
}
