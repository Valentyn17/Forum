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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum_PL.Controllers
{
    [ModelStateActionFilter]
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<MessageModel>>(_messageService.FindAll()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<MessageModel>(_messageService.FindById(id)));
        }

        [HttpGet("getByUserId/{id}")]
        public IActionResult GetByUserId(string id)
        {
            return Ok(_mapper.Map<IEnumerable<MessageModel>>(_messageService.FindByUserId(id)));
        }

        [HttpGet("getByTopicId/{id}")]
        public IActionResult GetByTopicId(int id)
        {
            return Ok(_mapper.Map<IEnumerable<MessageModel>>(_messageService.FindByTopicId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageModel model)
        {
            var message = _mapper.Map<MessageDTO>(model);
            await _messageService.CreateAsync(message);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Update(MessageModel model)
        {
            var message = _mapper.Map<MessageDTO>(model);
            await _messageService.UpdateAsync(message);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.DeleteAsync(id);
            return Ok();
        }
    }
}
