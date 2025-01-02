using Domin.Entities.Chat_Realted;
using Domin.Entities.Commin;
using Domin.Entities.Order_realted;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.UserEntities
{
	public class UserAccount :BaseEntity
	{
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string FullName { get; set; }
		public string? ProfilePictureUrl { get; set; }
		public bool IsEmailConfirmed { get; set; }
		public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
		public virtual ICollection<UserSession> UserSessions { get;set; } = new List<UserSession>();
		public virtual ICollection<Order> Orders { get; set; }
		public virtual Chat Chat { get; set; }
	}
}
