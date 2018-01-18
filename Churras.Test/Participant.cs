namespace Churras.Test
{
  public class Participant
  {
    public string Name { get; private set; }
    public decimal Dough { get; private set; }
    public bool IsGoingToDrink { get; private set; }

    public Participant(string name, decimal dough, bool isGoingToDrink)
    {
      this.Name = name;
      this.Dough = dough;
      this.IsGoingToDrink = isGoingToDrink;
    }
  }
}