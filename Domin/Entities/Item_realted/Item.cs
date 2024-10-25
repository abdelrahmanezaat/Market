using Domin.Entities.Category_realted;
using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.Item_realted
{
	public class Item:BaseLookupEntity
	{
		public string Manufacturer { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
		public DateTimeOffset ? ReleaseDate {  get; set; }
		public string ExpriyDuration { get; set; }
		public string ImageUrl { get; set; }
		public Guid CategoryId { get; set; }
		[ForeignKey(nameof(CategoryId))]
		public Category Category { get; set; }
	}
}
