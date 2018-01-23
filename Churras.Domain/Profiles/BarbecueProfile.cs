using AutoMapper;
using Churras.Domain.DTOs;
using Churras.Domain.Models;

public class BarbecueProfile : Profile
{
  public BarbecueProfile()
  {
    CreateMap<Barbecue, BarbecueDTO>();
    CreateMap<BarbecueDTO, Barbecue>();
  }
}