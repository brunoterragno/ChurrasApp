using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.DTOs;
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
        IMapper mapper;
        IBarbecueRepository barbecueRepository;

        public BarbecuesController(IMapper mapper, IBarbecueRepository barbecueRepository)
        {
            this.mapper = mapper;
            this.barbecueRepository = barbecueRepository;
        }

        [HttpGet]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(BarbecueDTO))]
        public IActionResult Get()
        {
            return Ok(mapper.Map<List<BarbecueDTO>>(barbecueRepository.Get()));
        }

        [HttpGet("{barbecueId}")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(BarbecueDTO))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult))]
        public IActionResult Get(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            return Ok(mapper.Map<BarbecueDTO>(barbecue));
        }

        [HttpPost]
        public IActionResult Post([FromBody] BarbecueDTO newBarbecue)
        {
            newBarbecue.Id = 0;
            var barbecue = barbecueRepository.Save(mapper.Map<Barbecue>(newBarbecue));

            return Created(
                $"api/barbecues/{barbecue.Id}",
                mapper.Map<BarbecueDTO>(barbecue)
            );
        }

        [HttpPut("{barbecueId}")]
        public IActionResult Put(int barbecueId, [FromBody] BarbecueDTO editedBarbecue)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            barbecue.ChangeTitle(editedBarbecue.Title);
            barbecue.ChangeDescription(editedBarbecue.Description);
            barbecue.ChangeDate(editedBarbecue.Date);
            barbecue.ChangeCostWithDrink(editedBarbecue.CostWithDrink);
            barbecue.ChangeCostWithoutDrink(editedBarbecue.CostWithoutDrink);
            barbecueRepository.Save(barbecue);

            return Ok(mapper.Map<BarbecueDTO>(barbecue));
        }

        [HttpDelete("{barbecueId}")]
        [SwaggerResponse((int) HttpStatusCode.NoContent)]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult))]
        public IActionResult Delete(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            barbecueRepository.Remove(barbecueId);

            return NoContent();
        }

        [HttpPost("{barbecueId}/participants")]
        public IActionResult Post(int barbecueId, [FromBody] ParticipantDTO newParticipant)
        {
            newParticipant.Id = 0;
            var barbecue = barbecueRepository.Get(barbecueId);
            var participant = mapper.Map<Participant>(newParticipant);
            barbecue.AddParticipant(participant);
            barbecueRepository.Save(barbecue);

            return Created(
                $"api/barbecues/{barbecue.Id}/participants/{participant.Id}",
                mapper.Map<ParticipantDTO>(participant)
            );
        }

        [HttpPut("{barbecueId}/participants/{participantId}")]
        public IActionResult Put(int barbecueId, int participantId, [FromBody] ParticipantDTO editedParticipant)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            var participant = barbecue.Participants.FirstOrDefault(x => x.Id == participantId);
            if (participant == null)
                throw new NotFoundException("participantId", "Resource not found", ErrorResultType.not_found);

            participant.ChangeName(editedParticipant.Name);
            participant.ChangeIsGoingToDrink(editedParticipant.IsGoingToDrink);
            participant.ChangeDough(editedParticipant.Dough);
            barbecueRepository.Save(barbecue);

            return Ok(mapper.Map<ParticipantDTO>(participant));
        }

        [HttpDelete("{barbecueId}/participants/{participantId}")]
        public IActionResult DeleteParticipant(int barbecueId, int participantId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            var participant = barbecue.Participants.FirstOrDefault(x => x.Id == participantId);
            if (participant == null)
                throw new NotFoundException("participantId", "Resource not found", ErrorResultType.not_found);

            barbecue.RemoveParticipant(participantId);
            barbecueRepository.Save(barbecue);

            return NoContent();
        }
    }
}