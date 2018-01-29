using System.Collections.Generic;
using Churras.Domain.Models;

namespace Churras.Domain.Contracts.Repositories
{
  public interface IBarbecueRepository
  {
    PagedList<Barbecue> Get(BarbecueResourceFilters pagination);

    Barbecue Get(int id);

    Barbecue Save(Barbecue barbecue);

    void Remove(int id);
  }
}