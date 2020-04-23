using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class AmenityModel : IValidatableObject
    {
        [Required(ErrorMessage = "The AmenityId is requiered.")]
        [Range(0, int.MaxValue, ErrorMessage = "The AmenityId number cannot be negative")]
        public int AmenityId { get; set; }
        [Required(ErrorMessage = "The Name is requiered.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Name should be alphanumeric")]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Category should be alphanumeric")]
        public string Category { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "The PricePerDay should be positive")]
        public decimal PricePerDay { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
