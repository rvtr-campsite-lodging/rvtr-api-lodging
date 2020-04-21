using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class BedModel : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Key]
    public int BedId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Size { get; set; }
    [Required]
    public decimal Amount { get; set; }

    public BedModel()
    {

    }

  }
}
