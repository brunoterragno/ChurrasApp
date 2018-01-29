using AutoMapper;
using Churras.Domain.Dtos;
using Churras.Domain.Models;

public class BarbecueProfile : Profile
{
  public BarbecueProfile()
  {
    CreateMap<Barbecue, BarbecueDto>();
    CreateMap<Barbecue, CreateEditBarbecueDto>();
    CreateMap<BarbecueDto, Barbecue>();
    CreateMap<CreateEditBarbecueDto, Barbecue>();
  }
}