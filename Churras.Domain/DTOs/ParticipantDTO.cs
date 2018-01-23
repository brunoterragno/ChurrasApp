using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.DTOs
{
  public class ParticipantDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Dough { get; set; }
    public bool IsGoingToDrink { get; set; }
  }

  public class ParticipantDTOValidator : AbstractValidator<ParticipantDTO>
  {
    public ParticipantDTOValidator()
    {
      RuleFor(b => b.Name)
        .NotEmpty();
    }
  }
}