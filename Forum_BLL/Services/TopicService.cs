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
    public class TopicService : ITopicService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TopicService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<TopicDTO> CreateAsync(TopicDTO model)
        {
            if (model == null)
            {
                throw new ForumException("Topic can't be created");
            }
            var topic = _mapper.Map<Topic>(model);
            await _unitOfWork.TopicRepository.AddAsync(topic);
            await _unitOfWork.SaveAsync();
            model.Id = topic.Id;
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.TopicRepository.DeletebyIdAsync(id);
            var result = await _unitOfWork.SaveAsync() != 0;
            return result;
        }

        public IEnumerable<TopicDTO> FindAll()
        {
            var topics = _unitOfWork.TopicRepository.GetAll(); 
            return _mapper.Map<IEnumerable<TopicDTO>>(topics);
        }

        public async Task<TopicDTO> FindByIdAsync(int id)
        {
            var topic =await  _unitOfWork.TopicRepository.GetByIdAsync(id);
            return _mapper.Map<TopicDTO>(topic);
        }

        public IEnumerable<TopicDTO> GetBySectionId(int id)
        {
            var topics = _unitOfWork.TopicRepository.GetAll().Where(t => t.SectionId == id);
            return _mapper.Map<IEnumerable<TopicDTO>>(topics);
        }

        public IEnumerable<TopicDTO> GetByUserId(string id)
        {
            var topics = _unitOfWork.TopicRepository.GetAll().Where(t => t.UserId == id);
            return _mapper.Map<IQueryable<TopicDTO>>(topics);
        }

        public async Task<bool> UpdateAsync(TopicDTO model)
        {
            if (model != null)
            {
                var topic = _mapper.Map<Topic>(model);
                _unitOfWork.TopicRepository.Update(topic);
                var result = await _unitOfWork.SaveAsync() != 0;
                return result;
            }
            else
            {
                throw new ForumException("Something goes wrong when you changed topic");
            }
        }
    }
}
