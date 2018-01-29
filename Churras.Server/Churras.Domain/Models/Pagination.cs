using FluentValidation;

namespace Churras.Domain.Models
{
  public class Pagination
  {
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
  }
}