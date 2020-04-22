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

    // [Fact]
    // public void Validation(){
    //   var sut = new ImageModel()
    //   {
    //     ImageId = 1,
    //     BlobUrl = ""
    //   };

    //   var context = new ValidationContext(sut, null, null);
    //   var results = new List<ValidationResult>();

    //   Assert.True(Validator.TryValidateObject(sut, context, results, true));
    // }

    [Theory]
    [InlineData(-1, "", false)]
    [InlineData(0, "blah", false)]
    [InlineData(1, "https://www.rspcasa.org.au/wp-content/uploads/2018/11/Puppy_dogtraining.jpg", true)]
    public void Valid(int id, string url, bool isValid)
    {
      ImageModel image = new ImageModel()
      {
        ImageId = id,
        BlobUrl= url
      };

      var validationResults = new List<ValidationResult>();
      var actual = Validator.TryValidateObject(image, new ValidationContext(image), validationResults, true);

      Assert.True(isValid.Equals(actual));
    }

  }
}
