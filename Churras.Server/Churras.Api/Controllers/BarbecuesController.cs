using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.Dtos;
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
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(BarbecueDto))]
        public IActionResult GetBarbecues()
        {
            return Ok(mapper.Map<List<BarbecueDto>>(barbecueRepository.Get()));
        }

        [HttpGet("{barbecueId}", Name = "GetBarbecue")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(BarbecueDto))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue not found")]
        public IActionResult GetBarbecue(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            return Ok(mapper.Map<BarbecueDto>(barbecue));
        }

        [HttpPost]
        [SwaggerResponse((int) HttpStatusCode.Created, typeof(BarbecueDto))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        public IActionResult PostBarbecue([FromBody] BarbecueDto newBarbecue)
        {
            newBarbecue.Id = 0;
            var barbecue = barbecueRepository.Save(mapper.Map<Barbecue>(newBarbecue));

            return CreatedAtRoute("GetBarbecue",
                new { barbecueId = barbecue.Id },
                mapper.Map<BarbecueDto>(barbecue)
            );
        }

        [HttpPut("{barbecueId}")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(BarbecueDto))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue not found")]
        public IActionResult PutBarbecue(int barbecueId, [FromBody] BarbecueDto editedBarbecue)
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

            return Ok(mapper.Map<BarbecueDto>(barbecue));
        }

        [HttpDelete("{barbecueId}")]
        [SwaggerResponse((int) HttpStatusCode.NoContent)]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue not found")]
        public IActionResult DeleteBarbecue(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            barbecueRepository.Remove(barbecueId);

            return NoContent();
        }

        [HttpGet("{barbecueId}/participants", Name = "GetParticipants")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(List<ParticipantDto>))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue not found")]
        public IActionResult GetParticipants(int barbecueId)
        {
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            return Ok(mapper.Map<List<ParticipantDto>>(barbecue.Participants));
        }

        [HttpPost("{barbecueId}/participants")]
        [SwaggerResponse((int) HttpStatusCode.Created, typeof(ParticipantDto))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue not found")]
        public IActionResult PostParticipant(int barbecueId, [FromBody] ParticipantDto newParticipant)
        {
            newParticipant.Id = 0;
            var barbecue = barbecueRepository.Get(barbecueId);
            if (barbecue == null)
                throw new NotFoundException("barbecueId", "Resource not found", ErrorResultType.not_found);

            var participant = mapper.Map<Participant>(newParticipant);
            barbecue.AddParticipant(participant);
            barbecueRepository.Save(barbecue);

            return CreatedAtRoute(
                "GetParticipants",
                new { barbecueId = barbecue.Id },
                mapper.Map<ParticipantDto>(participant)
            );
        }

        [HttpPut("{barbecueId}/participants/{participantId}")]
        [SwaggerResponse((int) HttpStatusCode.OK, typeof(ParticipantDto))]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Barbecue / Participant not found")]
        public IActionResult PutParticipant(int barbecueId, int participantId, [FromBody] ParticipantDto editedParticipant)
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

            return Ok(mapper.Map<ParticipantDto>(participant));
        }

        [HttpDelete("{barbecueId}/participants/{participantId}")]
        [SwaggerResponse((int) HttpStatusCode.NoContent)]
        [SwaggerResponse((int) HttpStatusCode.BadRequest, typeof(ValidationErrorResult))]
        [SwaggerResponse((int) HttpStatusCode.NotFound, typeof(ValidationErrorResult), "Participant not found")]
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