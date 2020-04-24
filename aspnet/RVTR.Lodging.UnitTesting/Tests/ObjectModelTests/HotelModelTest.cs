using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class HotelModelTest
    {

        [Fact]
        public void Test_MinimumHotel()
        {
            var sut = new HotelModel
            {
                HotelId = 1,
                Description = "",
                Type = "",
                Location = new LocationModel(),
                Area = 10.0,
                Reviews = new List<ReviewModel>(),
                Rooms = new List<RoomModel>{
                new RoomModel()
              },
                Images = new List<ImageModel>(),
                Amenities = new List<AmenityModel>()

            };

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, context, results, true));
        }

        [Fact]
        public void Test_Invalid()
        {
            var expectedErrors = new string[] { "HotelId", "Location", "Area", "Rooms" };

            var sut = new HotelModel
            {
                HotelId = -1,
                Description = "",
                Type = "",
                Area = -10.0,
                Reviews = new List<ReviewModel>(),
                Images = new List<ImageModel>(),
                Amenities = new List<AmenityModel>()
            };

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            Assert.False(Validator.TryValidateObject(sut, context, results, true));

            Assert.Equal(4, results.Count);

            for (int i = 0; i < expectedErrors.Length; i++)
            {
                Assert.Equal(expectedErrors[i], results[i].MemberNames.ToList()[0]);
            }
        }
    }
}
