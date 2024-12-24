using Domin.Entities.Commin;
using Domin.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domin.Entities.Chat_Realted
{
	public class Chat:BaseEntity
	{
		public Guid UserId { get; set; }
		[ForeignKey(nameof(UserId))]
		public virtual UserAccount UserAccount { get; set; }
		public virtual ICollection<Message> Messages { get; set; }
	}
}
