using System;
using System.Collections.Generic;
using Churras.Api.Models;
using Xunit;

namespace Churras.Test
{
  public class TestDataBuilder
  {
    public Barbecue GetDefaultBarbecue()
    {
      return new Barbecue(
        id : 1,
        title: "Churras Carnaval 1",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
        costWithDrink : 20,
        costWithoutDrink : 10
      );
    }

    public List<Barbecue> GetAllDefaultBarbecues()
    {
      return new List<Barbecue>()
      {
        new Barbecue(
            id : 1,
            title: "Churras Carnaval 1",
            date : DateTime.Now.AddDays(1).Date,
            description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
            costWithDrink : 20,
            costWithoutDrink : 10
          ),
          new Barbecue(
            id : 2,
            title: "Churras Carnaval 2",
            date : DateTime.Now.AddDays(2).Date,
            description: "Vamos comemorar todos juntos nessa folia de sexta-feira 2!",
            costWithDrink : 30,
            costWithoutDrink : 20
          ),
      };
    }

    public Participant GetNewParticipantWithDrink(Barbecue barbecue)
    {
      return new Participant(barbecue, name: "Bruno", dough : 20, isGoingToDrink : true);
    }

    public Participant GetNewParticipantWithDrinkButNotEnoughMoney(Barbecue barbecue)
    {
      return new Participant(barbecue, name: "Bruno", dough : 5, isGoingToDrink : true);
    }

    public Participant GetNewParticipantWithoutDrink(Barbecue barbecue)
    {
      return new Participant(barbecue, name: "Bruno", dough : 10, isGoingToDrink : false);
    }

    public ValidationErrorResult GetBarbecueBadRequestValidationErrorResult()
    {
      var expectedValidationError = new List<ValidationError>();
      expectedValidationError.Add(new ValidationError("Date", "'Date' must be greater than or equal to today.", ErrorResultType.invalid_parameter));
      expectedValidationError.Add(new ValidationError("Title", "'Title' should not be empty.", ErrorResultType.invalid_parameter));
      expectedValidationError.Add(new ValidationError("CostWithDrink", "'Cost With Drink' must be greater than '0'.", ErrorResultType.invalid_parameter));

      return new ValidationErrorResult("Error when requesting POST /api/barbecues", expectedValidationError);
    }
  }
}