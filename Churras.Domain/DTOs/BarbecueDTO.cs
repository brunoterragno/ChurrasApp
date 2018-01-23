using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.DTOs
{
  public class BarbecueDTO
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

    public List<Participant> Participants { get; set; }
  }

  public class BarbecueDTOValidator : AbstractValidator<BarbecueDTO>
  {
    public BarbecueDTOValidator()
    {
      RuleFor(b => b.Title)
        .NotEmpty();
      RuleFor(b => b.Date)
        .GreaterThanOrEqualTo(DateTime.Now.Date)
        .WithMessage("'Date' must be greater than or equal to today.");
      RuleFor(b => b.CostWithDrink)
        .GreaterThan(0);
    }
  }
}