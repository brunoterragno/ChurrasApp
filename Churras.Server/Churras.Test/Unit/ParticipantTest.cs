using System;
using Xunit;

namespace Churras.Test.Unit
{
    public class ParticipantTest : TestDataBuilder
    {
        [Fact]
        public void Change_Dough_When_With_Drink()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var newParticipant = GetNewParticipantWithDrink(barbecue);

            // Act 
            barbecue.AddParticipant(newParticipant);
            newParticipant.ChangeDough(30);

            // Assert
            Assert.Equal(30, barbecue.TotalDough);
        }

        [Fact]
        public void Cannot_Change_Dough_When_With_Drink_Cost_Is_Bigger_Than_It()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var newParticipant = GetNewParticipantWithDrink(barbecue);

            // Act & Assert
            barbecue.AddParticipant(newParticipant);
            Assert.ThrowsAny<ArgumentException>(() => newParticipant.ChangeDough(5));
        }

        [Fact]
        public void Cannot_Change_Dough_When_Without_Drink_Cost_Is_Bigger_Than_It()
        {
            // Arrange
            var barbecue = GetDefaultBarbecue();
            var newParticipant = GetNewParticipantWithoutDrink(barbecue);

            // Act & Assert
            barbecue.AddParticipant(newParticipant);
            Assert.ThrowsAny<ArgumentException>(() => newParticipant.ChangeDough(5));
        }
    }
}