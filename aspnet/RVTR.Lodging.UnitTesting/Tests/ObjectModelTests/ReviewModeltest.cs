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
        public void Validate_ReviewModel_Test()
        {
            var review = new ReviewModel
            {
                ReviewId = 1,
                UserId = 1,
                HotelId = 1,
                UserName = "username",
                Rating = 5,
                Content = "bad hotel"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(review, new ValidationContext(review), validationResults, true);


            Assert.True(actual, "Expected validation to succeed.");
        }
    }
}
