using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.Dtos
{
  public class BarbecueDto
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal CostWithDrink { get; set; }
    public decimal CostWithoutDrink { get; set; }
    public decimal TotalDough { get; set; }
    public int TotalParticipants { get; set; }
    public int TotalParticipantsWhoDrink { get; set; }
    public int TotalParticipantsWhoDontDrink { get; set; }

    public List<ParticipantDto> Participants { get; set; }
  }
}