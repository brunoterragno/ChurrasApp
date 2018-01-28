using System.Collections.Generic;
using Churras.Domain.Models;

namespace Churras.Domain.Contracts.Repositories
{
  public interface IBarbecueRepository
  {
    List<Barbecue> Get();

    Barbecue Get(int id);

    Barbecue Save(Barbecue barbecue);

    void Remove(int id);
  }
}