using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class AmenityModel : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int AmenityId { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    [Range(0, decimal.MaxValue)]
    public decimal PricePerDay { get; set; }
  }
}
