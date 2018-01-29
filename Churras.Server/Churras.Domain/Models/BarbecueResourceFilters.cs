using FluentValidation;

namespace Churras.Domain.Models
{
  public class BarbecueResourceFilters : Pagination
  {
    public string SearchTerm { get; set; }
  }

  public class BarbecueResourceFiltersValidator : AbstractValidator<BarbecueResourceFilters>
  {
    public BarbecueResourceFiltersValidator()
    {
      RuleFor(b => b.PageSize)
        .LessThanOrEqualTo(20);
    }
  }
}