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
    [Route("api/[controller]")]
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

        // GET: api/<SectionController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<SectionModel>(_sectionService.FindAll()));
        }

        // GET api/<SectionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SectionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SectionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
