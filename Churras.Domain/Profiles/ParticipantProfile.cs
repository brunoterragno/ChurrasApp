using AutoMapper;
using Churras.Domain.DTOs;
using Churras.Domain.Models;

public class ParticipantProfile : Profile
{
  public ParticipantProfile()
  {
    CreateMap<Participant, ParticipantDTO>();
    CreateMap<ParticipantDTO, Participant>();
  }
}