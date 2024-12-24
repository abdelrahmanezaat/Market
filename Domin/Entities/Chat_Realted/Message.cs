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
	public class Message:BaseEntity
	{
		public string Body { get; set; }
		public DateTimeOffset SendDate { get; set; }
		public bool IsSent { get; set; }
		public Guid ChatID { get; set; }
		[ForeignKey(nameof(ChatID))]
		public virtual Chat Chat { get; set; }

			

	}
}
