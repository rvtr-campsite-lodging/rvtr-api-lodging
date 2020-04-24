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
        [InlineData(1, "101 SOS WAY", "Fake City", "Stateopia", "90210", true, "es-ES", "positive test")]
        [InlineData(-1, "101 SOS WAY", "Fake City", "Stateopia", "90210", false, "es-ES", "negative ID")]
        [InlineData(1, null, "Fake City", "Stateopia", "90210", false, "es-ES", "bad address1")]
        [InlineData(1, "101 SOS WAY", null, "Stateopia", "90210", false, "es-ES", "bad city")]
        [InlineData(1, "101 SOS WAY", "Fake City", null, "90210", false, "es-ES", "bad state")]
        [InlineData(1, "101 SOS WAY", "Fake City", "Stateopia", null, false, "es-ES", "bad zip")]
        [InlineData(1, "101 SOS WAY", "Fake City", "Stateopia", "90210", false, "TOTALLYNOTACULTURE", "bad culture")]
        public void Test_Location(int id, string add1, string city, string state, string zip, bool passFail, string culture, string paramBeingTested)
        {
            var sut = new LocationModel
            {
                LocationId = id,
                Address1 = add1,
                City = city,
                State = state,
                Zip = zip,
                CultureInfo = culture
            };
            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.True(passFail.Equals(actual), "Validation testing " + paramBeingTested + " failed.");
        }
    }
}
