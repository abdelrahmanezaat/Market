﻿using Application.Dtos.ChatDtos_realted.MessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.IFeatures.IChat
{
	public  interface IMessageService
	{
		Task<GetMessageDto> SendMessage (CreateMessageDto model);
		Task<IEnumerable<GetMessageDto>> GetAllMessage(Guid ChatId);
	}
}