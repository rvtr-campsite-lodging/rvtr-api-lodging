using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;
using System.Collections.Generic;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class RoomTypeModelTest
    {
        [Fact]
        public void Validate_RoomType_Valid_Test()
        {
            var Bed = new BedModel();
            var Image = new ImageModel();
            var RoomType1 = new RoomTypeModel()
            {
                RoomTypeId = 1,
                Name = "1025",
                Beds = new List<BedModel> {Bed},
                Bathrooms = 2,
                Bedrooms = 3,
                BaseCapacity = 4,
                MaxCapacity = 6,
                PricePerNight = 80,
                PricePerAdditionalPerson = 100,
                Description = "Test Room Model",
                Images = new List<ImageModel> {Image}
            };
                // Act
                var validationResults = new List<ValidationResult>();
                var actual1 = Validator.TryValidateObject(RoomType1, new ValidationContext(RoomType1), validationResults, true);

                // Assert
                Assert.True(actual1, "Expected validation to succeed.");
        }

        [Theory]
        [InlineData(1, "name1", 2, 3, 4, 6, 80, 100, "Test Description",  true,  "Positive test")]
        [InlineData(-1, "name1",2, 3, 4, 6, 80, 100, "Test Description",  false, "RoomId negative")]
        [InlineData(1, "name1", -2, 3, 4, 6, 80, 100, "Test Description", false, "Bathrooms negative")]
        [InlineData(1, "name1", 2, -3, 4, 6, 80, 100, "Test Description", false, "Bedrooms negative")]
        [InlineData(1, "name1", 2, 3, -4, 6, 80, 100, "Test Description", false, "BaseCapacity negative")]
        [InlineData(1, "name1", 2, 3, 4, -6, 80, 100, "Test Description", false, "MaxCapacity negative")]
        [InlineData(1, "name1", 2, 3, 4, 6, 100, 80, "Test Description",  false, "PricePerAdditionalPerson greater than PricePerNight")]
        [InlineData(1, "name1", 2, 3, 6, 4, 80, 100, "Test Description", false, "MaxCapacity greater than BaseCapacity")]
        public void Test_Incorrect_RoomType(int id, string name, double bathrooms, double bedrooms, int basecapacity, int maxcapacity, int pricepernight, int priceperadditionalperson, string description, bool passFail, string paramBeingTested)
        {
            var beds = new List<BedModel>() {new BedModel()};
            var images = new List<ImageModel>() {new ImageModel()};
            var sut = new RoomTypeModel
            {
                RoomTypeId = id,
                Name = name,
                Beds = beds,
                Bathrooms = bathrooms,
                Bedrooms = bedrooms,
                BaseCapacity = basecapacity,
                MaxCapacity = maxcapacity,
                PricePerNight = pricepernight,
                PricePerAdditionalPerson = priceperadditionalperson,
                Description = description,
                Images = images
            };
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.True(passFail.Equals(actual), "Validation testing " + paramBeingTested + " failed.");
        }

    }
}
