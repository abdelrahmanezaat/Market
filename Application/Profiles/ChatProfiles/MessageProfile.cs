using Application.Dtos.ChatDtos_realted.MessageDtos;
using AutoMapper;
using Domin.Entities.Chat_Realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.ChatProfiles
{
	public class MessageProfile:Profile
	{
		public MessageProfile() 
		{
			CreateMap<CreateMessageDto,Message>();
			CreateMap<Message, GetMessageDto>();
		}
	}
}
