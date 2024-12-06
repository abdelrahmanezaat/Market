using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.UserEntities
{
	public class UserRole : BaseEntity
	{
		public Guid UserId { get; set; }
		public Guid RoleId { get; set; }
		[ForeignKey(nameof(UserId))]
		public virtual UserAccount UserAccount { get; set; }
		[ForeignKey(nameof(RoleId))]
		public virtual Role Role { get; set; }
	}
}
