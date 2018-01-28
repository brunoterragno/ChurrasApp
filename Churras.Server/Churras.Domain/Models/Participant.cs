using System;

namespace Churras.Domain.Models
{
  public class Participant
  {
    public int Id { get; set; }
    public string Name { get; private set; }
    public decimal Dough { get; private set; }
    public bool IsGoingToDrink { get; private set; }

    public int BarbecueId { get; private set; }
    public Barbecue Barbecue { get; private set; }

    public Participant() { }

    public Participant(Barbecue barbecue, string name, decimal dough, bool isGoingToDrink)
    {
      this.Barbecue = barbecue;
      this.BarbecueId = this.Barbecue.Id;
      this.Name = name;
      this.Dough = dough;
      this.IsGoingToDrink = isGoingToDrink;
    }

    public void ChangeName(string name)
    {
      this.Name = name;
    }

    public void ChangeDough(decimal dough)
    {
      if (this.IsGoingToDrink && dough < this.Barbecue.CostWithDrink)
        throw new ArgumentException("Can't give less money");

      if (this.IsGoingToDrink == false && dough < this.Barbecue.CostWithoutDrink)
        throw new ArgumentException("Can't give less money");

      this.Dough = dough;
    }

    public void ChangeIsGoingToDrink(bool isGoingToDrink)
    {
      this.IsGoingToDrink = isGoingToDrink;
    }
  }
}