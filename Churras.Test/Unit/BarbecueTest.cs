using System;
using Xunit;

namespace Churras.Test.Unit
{
    public class BarbecueTest : TestDataBuilder
    {
        [Fact]
        public void Create_New_Barbecue()
        {
            // Act
            var newBarbecue = GetDefaultBarbecue();

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
            var barbecue = GetDefaultBarbecue();
            var newParticipant = GetNewParticipantWithoutDrink(barbecue);

            // Act
            barbecue.AddParticipant(newParticipant);

            // Assert
            Assert.Equal(1, barbecue.Participants.Count);
            Assert.Same(newParticipant, barbecue.Participants[0]);
            Assert.Equal(10, barbecue.TotalDough);
        }

        [Fact]
        public void Should_Sum_All_Participants_Dough_And_Who_Drink_Or_Not()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var newParticipantOne = GetNewParticipantWithoutDrink(barbecue);
            var newParticipantTwo = GetNewParticipantWithoutDrink(barbecue);
            var newParticipantThree = GetNewParticipantWithDrink(barbecue);

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
            var barbecue = GetDefaultBarbecue();
            var newParticipant = GetNewParticipantWithDrinkButNotEnoughMoney(barbecue);

            // Act & Assert
            Assert.ThrowsAny<ArgumentException>(() => barbecue.AddParticipant(newParticipant));
        }

        [Fact]
        public void Remove_Participant_From_An_Existent_Barbecue()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var participant = GetNewParticipantWithoutDrink(barbecue);

            // Act
            barbecue.AddParticipant(participant);
            barbecue.RemoveParticipant(participant);

            // Assert
            Assert.Equal(0, barbecue.Participants.Count);
            Assert.Equal(0, barbecue.TotalDough);
        }

        [Fact]
        public void Remove_Unexistent_Participant_From_An_Existent_Barbecue()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var participant = GetNewParticipantWithoutDrink(barbecue);
            var notExistParticipant = GetNewParticipantWithDrink(barbecue);

            // Act
            barbecue.AddParticipant(participant);
            barbecue.RemoveParticipant(notExistParticipant);

            // Assert
            Assert.Equal(1, barbecue.Participants.Count);
            Assert.Equal(10, barbecue.TotalDough);
        }
    }
}