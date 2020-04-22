using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{

    public class HotelModel : IValidatableObject
    {
        [Required(ErrorMessage = "The HotelId is required")]
        public int HotelId { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [Required(ErrorMessage = "The Location is required")]
        public LocationModel Location { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The Area must be positive")]
        public double Area { get; set; }
        public List<ReviewModel> Reviews { get; set; }
        [Required(ErrorMessage = "The rooms are required")]
        public List<RoomModel> Rooms { get; set; }
        public List<ImageModel> Images { get; set; }
        public IEnumerable<AmenityModel> Amenities { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if (Rooms.Count == 0)
            {
                yield return new ValidationResult("The Rooms List must contain at least one Room", new[] { "Rooms" });
            }
        }
    }
}
