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
    /// <inheritdoc cref="ISectionService"/>
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor of sectionService
        /// </summary>
        /// <param name="mapper">Mapper </param>
        /// <param name="unitOfWork">Unit Of work</param>
        public SectionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<SectionDTO> CreateAsync(SectionDTO model)
        {
            if (model == null)
            {
                throw new ForumException("Section can't be created");
            }
            var section = _mapper.Map<Section>(model);
            await _unitOfWork.SectionRepository.AddAsync(section);
            await _unitOfWork.SaveAsync();
            model.Id = section.Id;
            return model;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.SectionRepository.DeletebyIdAsync(id);
            var result = await _unitOfWork.SaveAsync() != 0;
            return result;

        }

        public IEnumerable<SectionDTO> FindAll()
        {
            var sections = _unitOfWork.SectionRepository.GetAll();
            return _mapper.Map<IEnumerable<SectionDTO>>(sections);
        }

        public SectionDTO FindById(int id)
        {
            var section = _unitOfWork.SectionRepository.GetByIdAsync(id);
            return _mapper.Map<SectionDTO>(section);
        }

        public async Task<bool> UpdateAsync(SectionDTO model)
        {
            if (model != null)
            {
                var section = _mapper.Map<Section>(model);
                _unitOfWork.SectionRepository.Update(section);
                var result = await _unitOfWork.SaveAsync() != 0;
                return result;
            }
            else
            {
                throw new ForumException("Something goes wrong when you changed section");
            }
        }
    }
}
