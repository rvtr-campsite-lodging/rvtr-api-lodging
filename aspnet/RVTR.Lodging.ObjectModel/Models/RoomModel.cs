using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class RoomModel : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int RoomId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Name { get; set; }
    [Required]
    public RoomTypeModel Type { get; set; }

  }
}
