using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class HotelModel : IValidatableObject
    {
        /// <summary>
        /// Id of Hotel.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The HotelId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The HotelId number cannot be negative")]
        public int HotelId { get; set; }
        /// <summary>
        /// Description of Hotel.
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// Type of Hotel.
        /// </summary>
        /// <value></value>
        public string Type { get; set; }
        /// <summary>
        /// Location of Hotel.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Location is required")]
        public LocationModel Location { get; set; }
        /// <summary>
        /// Area of Hotel. (Units determined by CultureInfo)
        /// </summary>
        /// <value></value>
        [Range(0, double.MaxValue, ErrorMessage = "The Area must be positive")]
        public double Area { get; set; }
        /// <summary>
        /// List of Reviwes of Hotel.
        /// </summary>
        /// <value></value>
        public List<ReviewModel> Reviews { get; set; }
        /// <summary>
        /// List of Rooms of Hotel.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The rooms are required")]
        public List<RoomModel> Rooms { get; set; }
        /// <summary>
        /// List of Images of Hotel.
        /// </summary>
        /// <value></value>
        public List<ImageModel> Images { get; set; }
        /// <summary>
        /// List of Amenities of Hotel.
        /// </summary>
        /// <value></value>
        public List<AmenityModel> Amenities { get; set; }

        /// <summary>
        /// Validate that Rooms list contains at leats one Room.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if (Rooms.Count == 0)
            {
                yield return new ValidationResult("The Rooms List must contain at least one Room", new[] { "Rooms" });
            }
        }
    }
}
