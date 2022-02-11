
using AutoMapper;
using Forum_BLL.DTO;
using Forum_BLL.Interfaces;
using Forum_PL.Filters;
using Forum_PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Controllers
{
    [ModelStateActionFilter]
    [Route("[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _sectionService;

        private readonly IMapper _mapper;

        public SectionController(ISectionService sectionService, IMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<SectionModel>>(_sectionService.FindAll()));
        }

        [HttpGet("getSortedSections")]
        public IActionResult GetSorted()
        {
            return Ok(_mapper.Map<IEnumerable<SectionModel>>(_sectionService.GetSortedSectionsByTopicCount()));
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<SectionModel>(_sectionService.FindByIdAsync(id)));
        }


        [HttpPost]
        public async Task<IActionResult> Post(SectionModel model)
        {
            var section = _mapper.Map<SectionDTO>(model);
            await _sectionService.CreateAsync(section);
            return Ok();
        }

  
        [HttpPut()]
        public async Task<IActionResult> Put(SectionModel model)
        {
            var section = _mapper.Map<SectionDTO>(model);
            await _sectionService.UpdateAsync(section);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sectionService.DeleteAsync(id);
            return Ok();
        }

        
    }
}
