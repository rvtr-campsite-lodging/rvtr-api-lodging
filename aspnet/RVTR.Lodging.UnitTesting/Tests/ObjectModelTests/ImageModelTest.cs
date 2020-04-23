using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RVTR.Lodging.DataContext.Repositories;
using RVTR.Lodging.ObjectModel.Models;
using Xunit;

namespace RVTR.Lodging.UnitTesting.Tests
{
  public class ImageModelTest
  {
    [Theory]
    [InlineData(-1, "", false)]
    [InlineData(0, "blah", false)]
    [InlineData(1, "https://docs.microsoft.com/en-us/ef/ef6/saving/validation#ivalidatableobject", false)]
    [InlineData(2, "https://www.rspcasa.org.au/wp-content/uploads/2018/11/Puppy_dogtraining.jpg", true)]
    public void Valid(int id, string url, bool expected)
    {
      ImageModel image = new ImageModel()
      {
        ImageId = id,
        BlobUrl= url
      };

      var validationResults = new List<ValidationResult>();
      var actual = Validator.TryValidateObject(image, new ValidationContext(image), validationResults, true);

      Assert.True(expected.Equals(actual));
    }
  }
}
