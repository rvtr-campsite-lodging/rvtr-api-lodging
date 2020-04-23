using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{

    public class AmenityModelTest
    {
        [Theory]
        [InlineData(1,"name1","category1",100,true,"positive test")]
        [InlineData(-1,"name1","category1",100,false,"negative id")]
        [InlineData(1,"name1@","category1",100,false," bad Name")]
        [InlineData(1,"name1","category1@",100,false," bad Category")]
        [InlineData(1,"name1","category1",-100,false," negativePrice per day")]
        public void Validate_AmenityModel_Test(int id,string name,string category,decimal PPP,bool passFail,string paramBeingTested)
        {
            // Assemble
            var Amenity = new AmenityModel()
            {
                AmenityId = id,
                Name = name,
                Category = category,
                PricePerDay = PPP
            };

             // Act
           var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Amenity, new ValidationContext(Amenity), validationResults, true);
            //assert
            Assert.True(passFail.Equals(actual),"Validation testing " + paramBeingTested + " failed.");
        }
    }
}
