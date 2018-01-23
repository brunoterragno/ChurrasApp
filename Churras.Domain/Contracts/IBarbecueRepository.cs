using System.Collections.Generic;
using Churras.Domain.Models;

namespace Churras.Domain.Contracts.Repositories
{
  public interface IBarbecueRepository
  {
    List<Barbecue> Get();

    Barbecue Get(int id);

    Barbecue GetByParticipantId(int participantId);

    Barbecue Save(Barbecue barbecue);
  }
}