using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{

    public class BedModelTest
    {

        [Fact]
        public void Validate_BedModel_Test()
        {
            // Assemble
            var Bed = new BedModel()
            {
                BedId = 1,
                Size = "King",
                Amount = 100.00m
            };
            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Bed, new ValidationContext(Bed), validationResults, true);
            // Assert
            // Assert.True(actual, "Expected validation to succeed.");
            //Assert.Equal(0,validationResults.Count);
        }
    }
}
