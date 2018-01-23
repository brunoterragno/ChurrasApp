using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.Exceptions;
using Churras.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Churras.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BarbecuesController : Controller
    {
        IBarbecueRepository barbecueRepository;

        public BarbecuesController(IBarbecueRepository barbecueRepository)
        {
            this.barbecueRepository = barbecueRepository;
        }

        // GET api/barbecues
        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(Barbecue))]
        public IActionResult Get()
        {
            return Ok(barbecueRepository.Get());
        }

        // GET api/barbecues/5
        [HttpGet("{barbecueId}")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(Barbecue))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult))]
        public IActionResult Get(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("Id", "Resource not found", ErrorResultType.not_found);

            return Ok(barbecue);
        }

        // POST api/barbecues
        [HttpPost]
        public IActionResult Post([FromBody] Barbecue newBarbecue)
        {
            var barbecue = barbecueRepository.Save(newBarbecue);
            return Created($"api/barbecues/{barbecue.Id}", barbecue);
        }

        // POST api/barbecues/{barbecueId}/participants
        [HttpPost("{barbecueId}/participants")]
        public IActionResult Post([FromBody] Participant newParticipant)
        {
            var barbecue = barbecueRepository.Get(newParticipant.Barbecue.Id);
            barbecue.AddParticipant(newParticipant);
            barbecueRepository.Save(barbecue);

            return Created($"api/barbecues/{barbecue.Id}/participants/{newParticipant.Id}", newParticipant);
        }

        // POST api/barbecues/{id}/participants
        [HttpDelete("{barbecueId}/participants/{participantId}")]
        public IActionResult DeleteParticipant(int participantId)
        {
            var barbecue = barbecueRepository.GetByParticipantId(participantId);
            barbecue.RemoveParticipant(participantId);
            barbecueRepository.Save(barbecue);

            return NoContent();
        }

        // PUT api/barbecues/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/barbecues/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}