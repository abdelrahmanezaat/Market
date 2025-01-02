using Application.Contract.IFeatures.IChat;
using Application.Contract.IRepositories.ICommon;
using Application.Dtos.ChatDtos_realted.MessageDtos;
using AutoMapper;
using Domin.Entities.Chat_Realted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chat_Realted_imp
{
	public class MessageService:IMessageService
	{
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IBaseRepository<Message> _repository;
		protected readonly IMapper _mapper;
        public MessageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_repository = _unitOfWork.GetRepository<Message>();
			_mapper = mapper;
		}
		public async Task<GetMessageDto> SendMessage(CreateMessageDto model)
		{
			var message = _mapper.Map<Message>(model);
			await _repository.AddAsync(message);
			await _unitOfWork.SaveChangesAsync();
			return _mapper.Map<GetMessageDto>(message);
		}
		public async Task<IEnumerable<GetMessageDto>> GetAllMessage (Guid ChatId)
		{
			var messages = await _repository.FindAsync(x=>x.ChatID==ChatId,null,null,x=>x.SendDate);
			return _mapper.Map<IEnumerable<GetMessageDto>>(messages);	

		}
	}
}
