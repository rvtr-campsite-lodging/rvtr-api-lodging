using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;
using System.Collections.Generic;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class RoomTypeModelTest
    {
        /**
        * Represents the type of room lodigng contains. Each type has an identifier along with a descripiction giving the base capacity priced
        * at pricePerNight, and the maxCapacity which is priced at pricePerAdditionalPerson. It also contains a list of images and the number
        * of rooms.
        *
        * ```yaml
        * RoomTypeId: int;
        * Name: string;
        * Beds: List<BedModel>;
        * Bathrooms: double;
        * Bedrooms: double;
        * BaseCapacity: int;
        * MaxCapacity: int;
        * PricePerNight: int;
        * PricePerAdditionalPerson: int;
        * Description: string;
        * Images: List<Images>;
        * ```
        */
        [Fact]
        public void Validate_RoomType_Valid_Test()
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

            var RoomType1 = new RoomTypeModel()
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



            // Act
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(RoomType1, new ValidationContext(RoomType1), validationResults, true);

            // Assert
            Assert.True(actual, "Expected validation to succeed.");
        }
    }
}
