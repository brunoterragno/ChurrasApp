using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Churras.Api.Models;
using Churras.Api.Repositories;
using Churras.Api.Utils.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("{barbecueId}")]
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