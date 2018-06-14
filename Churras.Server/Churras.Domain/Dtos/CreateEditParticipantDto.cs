using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.Dtos
{
  public class CreateEditParticipantDto
  {
    public string Name { get; set; }
    public decimal Dough { get; set; }
    public bool IsGoingToDrink { get; set; }
  }

  public class CreateEditParticipantDtoValidator : AbstractValidator<CreateEditParticipantDto>
  {
    public CreateEditParticipantDtoValidator()
    {
      RuleFor(b => b.Name)
        .NotEmpty()
        .NotNull();
    }
  }
}