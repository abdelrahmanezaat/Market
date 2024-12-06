using Domin.Entities.Commin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.UserEntities
{
	public class Role: BaseLookupEntity
	{
		public virtual ICollection<UserRole> UserRoles { get; set; }
	}
}
