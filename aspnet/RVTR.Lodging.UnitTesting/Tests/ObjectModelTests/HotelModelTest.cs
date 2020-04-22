using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var sut = new HotelModel{
              HotelId = 1,
              Location = new LocationModel(),
              Rooms = new List<RoomModel>{
                new RoomModel()
              }
            };

            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();

            Assert.True(Validator.TryValidateObject(sut, context, results, true));
        }
    }
}
