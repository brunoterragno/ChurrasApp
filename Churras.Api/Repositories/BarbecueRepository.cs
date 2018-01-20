using System;
using System.Collections.Generic;
using System.Linq;
using Churras.Api.Models;

namespace Churras.Api.Repositories
{
  public class BarbecueRepository
  {
    List<Barbecue> barbecues = new List<Barbecue>();

    public BarbecueRepository()
    {
      barbecues.Add(new Barbecue(
        id : 1,
        title: "Churras Carnaval 1",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
        costWithDrink : 20,
        costWithoutDrink : 10
      ));
      barbecues.Add(new Barbecue(
        id : 2,
        title: "Churras Carnaval 2",
        date : DateTime.Now.AddDays(2).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 2!",
        costWithDrink : 30,
        costWithoutDrink : 20
      ));
    }

    public List<Barbecue> Get()
    {
      return barbecues;
    }

    public Barbecue Get(int id)
    {
      return barbecues.FirstOrDefault(b => b.Id == id);
    }

    public Barbecue GetByParticipantId(int participantId)
    {
      var barbecue = this.barbecues.First(x => x.Participants.Any(y => y.Id == participantId));
      return barbecue;
    }

    public Barbecue Save(Barbecue barbecue)
    {
      if (barbecue.Id == 0)
      {
        barbecue.Id = barbecues.Max(x => x.Id) + 1;
        this.barbecues.Add(barbecue);
      }
      else
      {
        var index = this.barbecues.FindIndex(x => x.Id == barbecue.Id);
        this.barbecues[index] = barbecue;
      }

      int counterId = 1;
      for (int i = 0; i < this.barbecues.Count; i++)
      {
        for (int y = 0; y < this.barbecues[i].Participants.Count; y++)
        {
          this.barbecues[i].Participants[y].Id = counterId;
          counterId++;
        }
      }

      return barbecue;
    }
  }
}