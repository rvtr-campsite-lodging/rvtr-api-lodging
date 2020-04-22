using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{

  public class HotelModel : IValidatableObject
  {
    [Required]
    public int HotelId { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    [Required]
    public LocationModel Location { get; set; }
    [Range(0, double.MaxValue)]
    public double Area { get; set; }
    public List<ReviewModel> Reviews { get; set; }
    [Required]
    public List<RoomModel> Rooms { get; set; }
    public List<ImageModel> Images { get; set; }
    public IEnumerable<AmenityModel> Amenities { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
  }
}
