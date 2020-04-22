using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;
using System.Collections.Generic;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class RoomModelTest
    {
        /**
        * Represents a room object that has an identifier, name, and the type of room it is (single bed, 4-person room, etc).
        *
        * ```yaml
        * roomId: int;
        * name: string;
        * type: RoomType;
        * ```
        */
        [Fact]
        public void Validate_Room_Valid_Test()
        {
            var Bed = new BedModel
            {
                BedId = 1,
                Size = "King",
                Amount = 100.00m
            };
            var Image = new ImageModel()
            {
                ImageId = 1,
                BlobUrl = ""
            };
            var RoomType = new RoomTypeModel()
            {
                RoomTypeId = 1,
                Name = "1025",
                Beds = new List<BedModel> {Bed},
                Bathrooms = 2,
                Bedrooms = 3,
                BaseCapacity = 4,
                MaxCapacity= 6,
                PricePerNight = 80,
                PricePerAdditionalPerson = 100,
                Description = "Test Room Model",
                Images = new List<ImageModel> {Image}
            };
            var Room1 = new RoomModel()
            {
                RoomId = 1,
                Name = "test",
                Type = new RoomTypeModel()
            };

            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Room1, new ValidationContext(Room1), validationResults, true);

            // Assert
            Assert.True(actual, "Expected validation to succeed.");
        }
    }
}
