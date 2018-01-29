using FluentValidation;

namespace Churras.Domain.Models
{
  public class BarbecueResourceFilters : Pagination
  {
    public string Title { get; set; }
  }
}