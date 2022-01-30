using AutoMapper;
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


        // GET: <MessageController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<MessageModel>>(_messageService.FindAll()));
        }

        // GET <MessageController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mapper.Map<MessageModel>(_messageService.FindByIdAsync(id)));
        }

        // POST api/<MessageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
