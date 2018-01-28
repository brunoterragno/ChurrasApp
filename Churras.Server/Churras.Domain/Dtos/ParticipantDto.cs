using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.Dtos
{
  public class ParticipantDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Dough { get; set; }
    public bool IsGoingToDrink { get; set; }
  }

  public class ParticipantDtoValidator : AbstractValidator<ParticipantDto>
  {
    public ParticipantDtoValidator()
    {
      RuleFor(b => b.Name)
        .NotEmpty();
    }
  }
}