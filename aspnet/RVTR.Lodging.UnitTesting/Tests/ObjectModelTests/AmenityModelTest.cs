// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using RVTR.Lodging.ObjectModel.Models;
// using Xunit;

// namespace RVTR.Lodging.UnitTesting.Tests
// {

//     public class AmenityModelTest
//     {

//         [Fact]
//         public void Validate_AmenityModel_Test()
//         {
//             // Assemble
//             AmenityModel Amenity = new AmenityModel()
//             {
//                 AmenityId = 1,
//                 Name = "name1",
//                 Category = "category1",
//                 PricePerDay = 100.00m
//             };
//             // Act
//             var validationResults = new List<ValidationResult>();
//             var actual = Validator.TryValidateObject(Amenity, new ValidationContext(Amenity), validationResults, true);
//             // Assert
//             // Assert.True(actual, "Expected validation to succeed.");
//             //Assert.Equal(0,validationResults.Count);
//         }
//     }
// }
