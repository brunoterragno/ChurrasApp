using FluentValidation;

namespace Churras.Domain.Models
{
  public class Pagination
  {
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
  }

  public class PaginationValidator : AbstractValidator<Pagination>
  {
    public PaginationValidator()
    {
      RuleFor(b => b.PageSize)
        .LessThanOrEqualTo(20);
    }
  }
}