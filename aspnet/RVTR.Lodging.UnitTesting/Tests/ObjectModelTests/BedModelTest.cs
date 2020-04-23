using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{

    public class BedModelTest
    {



        [Theory]
        [InlineData(1,"King", 2, true,"Positive test")]
        [InlineData(-1,"King", 2, false,"negative id")]
        [InlineData(1,"gfhg", 2, false,"invalid size")]
        [InlineData(1,"King", -1, false,"negative Number of Beds")]
        public void Validate_BedModel_Test(int id, string name,int NOB,bool passFail,string paramBeingTested)
        {
            // Assemble
            var Bed = new BedModel()
            {
                BedId = id,
                Size = name,
                NumberOfBeds = NOB
            };
            // Act
           var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(Bed, new ValidationContext(Bed), validationResults, true);
            //assert
            Assert.True(passFail.Equals(actual),"Validation testing " + paramBeingTested + " failed.");
        }


    }
}
