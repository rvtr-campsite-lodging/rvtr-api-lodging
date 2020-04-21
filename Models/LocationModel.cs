using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class LocationModel : IValidatableObject
  {
    [Required]
    public int LocationId { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Address1 { get; set; }

    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Address2 { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string City { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string State { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Zip { get; set; }

    public double latitude { get; set; }

    public double longitude { get; set; }

    public string CultureInfo { get; set; }

    public LocationModel() { }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      IEnumerable<ValidationResult> results = new List<ValidationResult>();
      // Validator.TryValidateObject(LocationId, validationContext, results, true);
      // Validator.TryValidateObject(Address1, validationContext, results, true);
      // Validator.TryValidateObject(City, validationContext, results, true);
      // Validator.TryValidateObject(State, validationContext, results, true);
      // Validator.TryValidateObject(Zip, validationContext, results, true);
      return results;
    }
  }
}
