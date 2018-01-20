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

    public Barbecue Add(Barbecue barbecue)
    {
      barbecue.Id = barbecues.Max(x => x.Id) + 1;
      this.barbecues.Add(barbecue);

      return barbecue;
    }
  }
}