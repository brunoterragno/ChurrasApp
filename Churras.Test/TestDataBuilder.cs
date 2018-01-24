using System;
using System.Collections.Generic;
using Churras.Domain.Models;
using Xunit;

namespace Churras.Test
{
  public class TestDataBuilder
  {
    public Barbecue GetDefaultBarbecue()
    {
      var barbecueOne = new Barbecue(
        title: "Churras Carnaval 1",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
        costWithDrink : 20,
        costWithoutDrink : 10
      );
      barbecueOne.Id = 1;

      return barbecueOne;
    }

    public List<Barbecue> GetAllDefaultBarbecues()
    {
      var list = new List<Barbecue>();
      var barbecueOne = new Barbecue(
        title: "Churras Carnaval 1",
        date : DateTime.Now.AddDays(1).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 1!",
        costWithDrink : 20,
        costWithoutDrink : 10
      );
      barbecueOne.Id = 1;

      var barbecueTwo = new Barbecue(
        title: "Churras Carnaval 2",
        date : DateTime.Now.AddDays(2).Date,
        description: "Vamos comemorar todos juntos nessa folia de sexta-feira 2!",
        costWithDrink : 30,
        costWithoutDrink : 20
      );
      barbecueTwo.Id = 2;

      list.Add(barbecueOne);
      list.Add(barbecueTwo);

      return list;
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

    public List<ValidationError> GetBarbecueValidationErrors()
    {
      var expectedValidationError = new List<ValidationError>();
      expectedValidationError.Add(new ValidationError("Date", "'Date' must be greater than or equal to today.", ErrorResultType.invalid_parameter));
      expectedValidationError.Add(new ValidationError("Title", "'Title' should not be empty.", ErrorResultType.invalid_parameter));
      expectedValidationError.Add(new ValidationError("CostWithDrink", "'Cost With Drink' must be greater than '0'.", ErrorResultType.invalid_parameter));

      return expectedValidationError;
    }

    public ValidationErrorResult GetBarbecuePostBadRequestValidationErrorResult()
    {
      return new ValidationErrorResult("Error when requesting POST /api/barbecues", GetBarbecueValidationErrors());
    }

    public ValidationErrorResult GetBarbecuePutBadRequestValidationErrorResult()
    {
      return new ValidationErrorResult("Error when requesting PUT /api/barbecues/1", GetBarbecueValidationErrors());
    }
  }
}