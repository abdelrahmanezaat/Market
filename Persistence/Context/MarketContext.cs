﻿using Domin.Entities.Category_realted;
using Domin.Entities.Chat_Realted;
using Domin.Entities.Item_realted;
using Domin.Entities.Order_realted;
using Domin.Entities.UserEntities;
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
		public DbSet<UserAccount> UserAccounts { get; set; }
		public DbSet<UserRole> UserRoles { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<UserSession> UserSessions { get; set; }
		public DbSet<Order > Orders { get; set; }
		public DbSet<Chat> Chats { get; set; }
		public DbSet<Message> Messages { get; set; }

	}
}
