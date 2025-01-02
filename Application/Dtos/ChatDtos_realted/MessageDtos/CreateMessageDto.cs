using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.ChatDtos_realted.MessageDtos
{
	public  class CreateMessageDto
	{
		public string Body { get; set; }
		public DateTimeOffset SendDate { get; set; }
		public bool IsSent { get; set; }
		public Guid ChatId { get; set; }	

	}
}
