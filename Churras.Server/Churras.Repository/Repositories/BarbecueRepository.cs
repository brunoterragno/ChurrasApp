using System;
using System.Collections.Generic;
using System.Linq;
using Churras.Domain.Contracts.Repositories;
using Churras.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
      return context.Barbecues.Include(x => x.Participants).ToList();
    }

    public Barbecue Get(int id)
    {
      return context.Barbecues.Include(x => x.Participants).FirstOrDefault(b => b.Id == id);
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

    public void Remove(int id)
    {
      var barbecue = context.Barbecues.FirstOrDefault(b => b.Id == id);
      context.Remove(barbecue);

      context.SaveChanges();
    }
  }
}