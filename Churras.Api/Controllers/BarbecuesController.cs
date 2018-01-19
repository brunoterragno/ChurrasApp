using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Churras.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Churras.Api.Controllers
{
    [Route("api/[controller]")]
    public class BarbecuesController : Controller
    {
        // GET api/barbecues
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new List<Barbecue>()
            {
                new Barbecue(
                        title: "Churras Carnaval 1",
                        date : DateTime.Now.AddDays(1).Date,
                        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
                        costWithDrink : 20,
                        costWithoutDrink : 10
                    ),
                    new Barbecue(
                        title: "Churras Carnaval 2",
                        date : DateTime.Now.AddDays(2).Date,
                        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 2!",
                        costWithDrink : 30,
                        costWithoutDrink : 20
                    ),
            });
        }

        // GET api/barbecues/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 99)
            {
                return NotFound();
            }

            return Ok(new Barbecue(
                title: "Churras Carnaval",
                date : DateTime.Now.AddDays(1).Date,
                description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
                costWithDrink : 20,
                costWithoutDrink : 10
            ));
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