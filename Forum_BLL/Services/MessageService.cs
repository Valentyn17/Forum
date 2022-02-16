using AutoMapper;
using Forum_BLL.DTO;
using Forum_BLL.Interfaces;
using Forum_BLL.Validation;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Services
{
    /// <inheritdoc cref="IMessageService"/>
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of Message Service
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="unitOfWork">unit of work</param>
        public MessageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<MessageDTO> CreateAsync(MessageDTO model)
        {
            if (model == null)
            {
                throw new ForumException("Message can't be created");
            }
            var message = _mapper.Map<Message>(model);
            await _unitOfWork.MessageRepository.AddAsync(message);
            await _unitOfWork.SaveAsync();
            model.Id = message.Id;
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.MessageRepository.DeletebyIdAsync(id);
            var result= await _unitOfWork.SaveAsync()!=0;
            return result;
        }

        public IEnumerable<MessageDTO> FindAll()
        {
            var messages = _unitOfWork.MessageRepository.GetAll();
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public MessageDTO FindById(int id)
        {
            var message =_unitOfWork.MessageRepository.GetById(id);
            if (message == null)
                return null;
            return _mapper.Map<MessageDTO>(message);
        }

        public IQueryable<MessageDTO> FindByUserId(string userId)
        {
            if (userId == null)
                throw new ForumException("Id was not setted");
            var messages = _unitOfWork.MessageRepository.GetAll().Where(m => m.UserId == userId);
            return _mapper.Map<IQueryable<MessageDTO>>(messages);
        }

        public IEnumerable<MessageDTO> FindByTopicId(int topicId)
        {
            var messages = _unitOfWork.MessageRepository.GetAll().Where(m => m.TopicId == topicId);
            return _mapper.Map<IEnumerable<MessageDTO>>(messages);
        }

        public async Task<bool> UpdateAsync(MessageDTO model)
        {
            if (model != null)
            {
                var message = _mapper.Map<Message>(model);
                _unitOfWork.MessageRepository.Update(message);
                var result = await _unitOfWork.SaveAsync() != 0;
                return result;
            }
            else {
                throw new ForumException("Something goes wrong when you changed message");
            }
        }
    }
}
