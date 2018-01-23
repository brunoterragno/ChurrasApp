using System;
using Churras.Domain.Models;

namespace Churras.Repository
{
  public static class Seed
  {
    public static void EnsureSeedData(this ChurrasContext context)
    {
      if (context.AllMigrationsApplied())
      {
        AddTestData(context);
      }
    }

    public static void AddTestData(this ChurrasContext context)
    {
      context.Barbecues.Add(new Barbecue(
        title: "Churras Carnaval 1",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
        costWithDrink : 20,
        costWithoutDrink : 10
      ));

      context.Barbecues.Add(new Barbecue(
        title: "Churras Carnaval 2",
        date : DateTime.Now.AddDays(2).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 2!",
        costWithDrink : 30,
        costWithoutDrink : 20
      ));

      context.SaveChanges();

      Console.WriteLine("TestData: Added");
    }
  }
}