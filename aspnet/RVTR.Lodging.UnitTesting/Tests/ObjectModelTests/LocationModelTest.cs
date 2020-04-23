using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class LocationModelTest
    {

        [Theory]
        [InlineData(1, "101 SOS WAY", "Fake City", "Stateopia", "90210", true, "positive test")]
        [InlineData(-1, "101 SOS WAY", "Fake City", "Stateopia", "90210", false, "negative ID")]
        [InlineData(1, null, "Fake City", "Stateopia", "90210", false, "bad address1")]
        [InlineData(1, "101 SOS WAY", null, "Stateopia", "90210", false, "bad city")]
        [InlineData(1, "101 SOS WAY", "Fake City", null, "90210", false, "bad state")]
        [InlineData(1, "101 SOS WAY", "Fake City", "Stateopia", null, false, "bad zip")]
        public void Test_Location(int id, string add1, string city, string state, string zip, bool passFail, string paramBeingTested)
        {
            var sut = new LocationModel
            {
                LocationId = id,
                Address1 = add1,
                City = city,
                State = state,
                Zip = zip
            };
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.True(passFail.Equals(actual), "Validation testing " + paramBeingTested + " failed.");
        }
    }
}
