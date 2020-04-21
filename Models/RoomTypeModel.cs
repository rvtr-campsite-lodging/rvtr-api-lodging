using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class RoomTypeodel : IValidatableObject
  {
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    [Required]
    public int RoomTypeId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]*$")]
    public string Name { get; set; }
    [Required]
    public Bed[] Beds { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public Double Bathrooms { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public Double Bedrooms { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int BaseCapacity { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int PricePerNight { get; set; }
    [Range(0, int.MaxValue)]
    public int PricePerAdditionalPerson { get; set; }
    public string Description { get; set; }
    public Images[] Imgs { get; set; }

  }
}
