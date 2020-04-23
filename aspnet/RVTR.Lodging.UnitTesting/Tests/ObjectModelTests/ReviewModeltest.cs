using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
    public class ReviewModelTest
    {
        [Fact]
        public void Valid_ReviewModel_Test()
        {
            var sut = new ReviewModel
            {
                ReviewId = 1,
                UserId = 1,
                HotelId = 1,
                UserName = "username",
                Rating = 1,
                Content = "the worst hotel"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.True(actual, "Expected validation to succeed.");
        }

        [Fact]
        public void InValid_ReviewModel_Test()
        {
            var sut = new ReviewModel
            {
                ReviewId = -1,
                UserId = -1,
                HotelId = -1,
                UserName = "",
                Rating = 0,
                Content = ""
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(sut, new ValidationContext(sut), validationResults, true);

            Assert.False(actual, "Expected validation to failed.");
        }
    }
}
