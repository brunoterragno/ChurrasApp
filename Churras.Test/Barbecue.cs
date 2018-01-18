using System;
using System.Collections.Generic;
using System.Linq;

namespace Churras.Test
{
  public class Barbecue
  {
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public decimal CostWithDrink { get; private set; }
    public decimal CostWithoutDrink { get; private set; }

    public decimal TotalDough { get => Participants.Sum(x => x.Dough); }
    public int TotalParticipants { get => Participants.Count; }
    public int TotalParticipantsWhoDrink { get => Participants.Count(p => p.IsGoingToDrink); }
    public int TotalParticipantsWhoDontDrink { get => Participants.Count(p => !p.IsGoingToDrink); }

    public List<Participant> Participants { get; private set; } = new List<Participant>();

    public Barbecue(string title, DateTime date, string description, decimal costWithDrink, decimal costWithoutDrink)
    {
      this.Title = title;
      this.Date = date;
      this.Description = description;
      this.CostWithDrink = costWithDrink;
      this.CostWithoutDrink = costWithoutDrink;
    }

    public void AddParticipant(Participant newParticipant)
    {
      if (newParticipant.IsGoingToDrink && newParticipant.Dough < CostWithDrink)
        throw new ArgumentException("Should give more money");

      this.Participants.Add(newParticipant);
    }
  }
}