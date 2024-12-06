using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.UserEntities
{
	public class UserSession : BaseEntity
	{
		public string RefreshToken { get; set; }
		public DateTimeOffset RefreshTokenExpirationDate { get; set; }
		public Guid UserAccountId { get; set; }
		[ForeignKey(nameof(UserAccountId))]
		public virtual UserAccount UserAccount { get; set; }
	}
}
