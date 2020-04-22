using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class LocationModel : IValidatableObject
    {
        [Required(ErrorMessage = "The LocationId is required")]
        public int LocationId { get; set; }
        [Required(ErrorMessage = "Address1 is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Address1 should be alphanumeric")]
        public string Address1 { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Address2 should be alphanumeric")]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "The City is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The City should be alphanumeric")]
        public string City { get; set; }
        [Required(ErrorMessage = "The State is requiered")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The State should be alphanumeric")]
        public string State { get; set; }
        [Required(ErrorMessage = "The Zip is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Zip should be alphanumeric")]
        [MinLength(5),MaxLength(5)]
        public string Zip { get; set; }
        [Range(-90, 90, ErrorMessage = "The Latitude should be between -90 and 90")]
        public double latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "The Longitude should be between -180 and 180")]
        public double longitude { get; set; }
        public CultureInfo CultureInfo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
