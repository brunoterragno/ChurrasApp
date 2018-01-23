using System;
using System.Collections.Generic;
using System.Linq;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.Models;

namespace Churras.Repository.Repositories
{
  public class BarbecueRepository : IBarbecueRepository
  {
    ChurrasContext context;

    public BarbecueRepository(ChurrasContext context)
    {
      this.context = context;
    }
    public List<Barbecue> Get()
    {
      return context.Barbecues.ToList();
    }

    public Barbecue Get(int id)
    {
      return context.Barbecues.FirstOrDefault(b => b.Id == id);
    }

    public Barbecue GetByParticipantId(int participantId)
    {
      var barbecue = context.Barbecues.First(x => x.Participants.Any(y => y.Id == participantId));
      return barbecue;
    }

    public Barbecue Save(Barbecue barbecue)
    {
      if (barbecue.Id == 0)
      {
        context.Barbecues.Add(barbecue);
      }
      else
      {
        context.Barbecues.Update(barbecue);
      }

      context.SaveChanges();

      return barbecue;
    }
  }
}