using AutoMapper;
using Churras.Domain.Dtos;
using Churras.Domain.Models;

public class ParticipantProfile : Profile
{
  public ParticipantProfile()
  {
    CreateMap<Participant, ParticipantDto>();
    CreateMap<Participant, CreateEditParticipantDto>();
    CreateMap<ParticipantDto, Participant>();
    CreateMap<CreateEditParticipantDto, Participant>();
  }
}