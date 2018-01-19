using System;
using Xunit;

namespace Churras.Test
{
  public class TestDataBuilder
  {
    public Barbecue GetDefaultBarbecue()
    {
      return new Barbecue(
        title: "Churras Carnaval",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
        costWithDrink : 20,
        costWithoutDrink : 10
      );
    }

    public Participant GetNewParticipantWithDrink(Barbecue barbecue)
    {
      return new Participant(barbecue, name: "Bruno", dough : 20, isGoingToDrink : true);
    }

    public Participant GetNewParticipantWithoutDrink(Barbecue barbecue)
    {
      return new Participant(barbecue, name: "Bruno", dough : 10, isGoingToDrink : false);
    }
  }
}