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
    public class TopicController : ControllerBase
    {

        private readonly ITopicService _topicService;

        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService,IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<TopicModel>>(_topicService.FindAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<TopicModel>(_topicService.FindById(id)));
        }

        [HttpGet("getByUserId/{id}")]
        public IActionResult GetByUserId(string id)
        {
            return Ok(_mapper.Map<IEnumerable<TopicModel>>(_topicService.GetByUserId(id)));
        }
        
        
        [HttpGet("getBySectionId/{id}")]
        public IActionResult GetBySectionId(int id)
        {
            return Ok(_mapper.Map<IEnumerable<TopicModel>>(_topicService.GetBySectionId(id)));
        }



        [HttpPost]
        public async Task<IActionResult> Create(TopicModel model)
        {
            var topic = _mapper.Map<TopicDTO>(model);
            await _topicService.CreateAsync(topic);

            return Ok();

        }


        [HttpPut]
        public async Task<IActionResult> Update(TopicModel model)
        {
            var topic = _mapper.Map<TopicDTO>(model);
            await _topicService.UpdateAsync(topic);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _topicService.DeleteAsync(id);
            return Ok();
        }
    }
}
