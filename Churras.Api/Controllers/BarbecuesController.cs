using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Churras.Api.Models;
using Churras.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarbecuesController : Controller
    {
        BarbecueRepository barbecueRepository;

        public BarbecuesController()
        {
            barbecueRepository = new BarbecueRepository();
        }
        // GET api/barbecues
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(barbecueRepository.Get());
        }

        // GET api/barbecues/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var barbecue = barbecueRepository.Get(id);
            if (barbecue == null)
                return NotFound();

            return Ok(barbecue);
        }

        // POST api/barbecues
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT api/barbecues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/barbecues/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}