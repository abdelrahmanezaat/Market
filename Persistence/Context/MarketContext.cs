using Domin.Entities.Category_realted;
using Domin.Entities.Item_realted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
	public class MarketContext:DbContext
	{
		public MarketContext(DbContextOptions<MarketContext> options) : base(options)
		{
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Item> Items { get; set; }

	}
}
