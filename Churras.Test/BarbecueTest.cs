using System;
using Xunit;

namespace Churras.Test
{
    public class BarbecueTest
    {
        [Fact]
        public void Create_New_Barbecue()
        {
            // Act
            var newBarbecue = new Barbecue(
                title: "Churras Carnaval",
                date : DateTime.Now.AddDays(1).Date,
                description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
                costWithDrink : 20,
                costWithoutDrink : 10
            );

            // Assert
            Assert.Equal("Churras Carnaval", newBarbecue.Title);
            Assert.Equal(DateTime.Now.AddDays(1).Date, newBarbecue.Date);
            Assert.Equal("Vamos comemorar todos juntos nessa folia de sexta-feira!",
                newBarbecue.Description);
            Assert.Equal(20, newBarbecue.CostWithDrink);
            Assert.Equal(10, newBarbecue.CostWithoutDrink);
        }

        [Fact]
        public void Add_New_Participant()
        {
            // Arrange
            var barbecue = new Barbecue(
                title: "Churras Carnaval",
                date : DateTime.Now.AddDays(1).Date,
                description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
                costWithDrink : 20,
                costWithoutDrink : 10
            );
            var newParticipant = new Participant(name: "Bruno", dough : 5, isGoingToDrink : false);

            // Act
            barbecue.AddParticipant(newParticipant);

            // Assert
            Assert.Equal(1, barbecue.Participants.Count);
            Assert.Same(newParticipant, barbecue.Participants[0]);
            Assert.Equal(5, barbecue.TotalDough);
        }

        [Fact]
        public void Should_Sum_All_Participants_Dough_And_Who_Drink_Or_Not()
        {
            // Arrange
            var barbecue = new Barbecue(
                title: "Churras Carnaval",
                date : DateTime.Now.AddDays(1).Date,
                description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
                costWithDrink : 20,
                costWithoutDrink : 10
            );
            var newParticipantOne = new Participant(name: "Bruno", dough : 5, isGoingToDrink : false);
            var newParticipantTwo = new Participant(name: "Bruno", dough : 10, isGoingToDrink : false);
            var newParticipantThree = new Participant(name: "Bruno", dough : 25, isGoingToDrink : true);

            // Act
            barbecue.AddParticipant(newParticipantOne);
            barbecue.AddParticipant(newParticipantTwo);
            barbecue.AddParticipant(newParticipantThree);

            // Assert
            Assert.Equal(40, barbecue.TotalDough);
            Assert.Equal(3, barbecue.TotalParticipants);
            Assert.Equal(1, barbecue.TotalParticipantsWhoDrink);
            Assert.Equal(2, barbecue.TotalParticipantsWhoDontDrink);
        }

        [Fact]
        public void Cannot_Add_New_Participant_When_Dough_Isnt_Enough()
        {
            // Arrange
            var barbecue = new Barbecue(
                title: "Churras Carnaval",
                date : DateTime.Now.AddDays(1).Date,
                description: "Vamos comemorar todos juntos nessa folia de sexta-feira!",
                costWithDrink : 20,
                costWithoutDrink : 10
            );
            var newParticipant = new Participant(name: "Bruno", dough : 5, isGoingToDrink : true);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => barbecue.AddParticipant(newParticipant));
        }
    }
}