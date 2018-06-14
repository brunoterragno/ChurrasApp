using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using FluentValidation;

namespace Churras.Domain.Dtos
{
  public class CreateEditBarbecueDto
  {
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal CostWithDrink { get; set; }
    public decimal CostWithoutDrink { get; set; }
  }

  public class CreateEditBarbecueDtoValidator : AbstractValidator<CreateEditBarbecueDto>
  {
    public CreateEditBarbecueDtoValidator()
    {
      RuleFor(b => b.Title)
        .NotEmpty()
        .NotNull();
      RuleFor(b => b.Date)
        .NotEmpty()
        .NotNull()
        .GreaterThanOrEqualTo(DateTime.Now.Date)
        .WithMessage("'Date' must be greater than or equal to today.");
      RuleFor(b => b.CostWithDrink)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);
    }
  }
}