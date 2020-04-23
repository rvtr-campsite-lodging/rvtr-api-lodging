using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;
using System.Collections.Generic;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class RoomModelTest
    {
        [Fact]
        public void Validate_Room_Correct_Test()
        {
            var Room1 = new RoomModel()
            {
                RoomId = 1,
                Name = "test",
                Type = new RoomTypeModel()
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual1 = Validator.TryValidateObject(Room1, new ValidationContext(Room1), validationResults, true);

            // Assert
            Assert.True(actual1, "Expected validation to succeed.");
        }

        [Theory]
        [InlineData(1, "TestName", true, "Positive Test")]
        [InlineData(-1, "TestName", false, "Negative RoomId")]
        [InlineData(1, "#Symbol#Name", false, "Symbols in Name")]
        public void Validate_Room_Wrong_Test(int roomid, string name, bool passFail, string paramBeingTested)
        {
            var type = new RoomTypeModel();
            var sut = new RoomModel()
            {
                RoomId = roomid,
                Name = name,
                Type = type
            };
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.True(passFail.Equals(actual), "Validation testing " + paramBeingTested + " failed.");
        }
    }
}
