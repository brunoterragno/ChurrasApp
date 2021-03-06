using System;
using System.Collections.Generic;
using System.Linq;

namespace Churras.Domain.Models
{
  public class Barbecue
  {
    public int Id { get; set; }
    public string Title { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public decimal CostWithDrink { get; private set; }
    public decimal CostWithoutDrink { get; private set; }

    public decimal TotalDough { get => Participants.Sum(x => x.Dough); }
    public int TotalParticipants { get => Participants.Count; }
    public int TotalParticipantsWhoDrink { get => Participants.Count(p => p.IsGoingToDrink); }
    public int TotalParticipantsWhoDontDrink { get => Participants.Count(p => !p.IsGoingToDrink); }

    private readonly List<Participant> _participants = new List<Participant>();
    public IReadOnlyList<Participant> Participants => _participants;

    public Barbecue() { }

    public Barbecue(string title, DateTime date, string description, decimal costWithDrink, decimal costWithoutDrink)
    {
      this.Title = title;
      this.Date = date;
      this.Description = description;
      this.CostWithDrink = costWithDrink;
      this.CostWithoutDrink = costWithoutDrink;
    }

    public void ChangeTitle(string title)
    {
      this.Title = title;
    }

    public void ChangeDate(DateTime date)
    {
      this.Date = date;
    }

    public void AddParticipant(Participant newParticipant)
    {
      if (newParticipant.IsGoingToDrink && newParticipant.Dough < CostWithDrink)
        throw new ArgumentException("Should give more money");

      if (newParticipant.IsGoingToDrink == false && newParticipant.Dough < CostWithoutDrink)
        throw new ArgumentException("Should give more money");

      this._participants.Add(newParticipant);
    }

    public void RemoveParticipant(int participantId)
    {
      var participant = this._participants.FirstOrDefault(p => p.Id == participantId);
      this._participants.Remove(participant);
    }

    public void ChangeDescription(string description)
    {
      this.Description = description;
    }

    public void ChangeCostWithDrink(decimal costWithDrink)
    {
      this.CostWithDrink = costWithDrink;
    }

    public void ChangeCostWithoutDrink(decimal costWithoutDrink)
    {
      this.CostWithoutDrink = costWithoutDrink;
    }
  }
}