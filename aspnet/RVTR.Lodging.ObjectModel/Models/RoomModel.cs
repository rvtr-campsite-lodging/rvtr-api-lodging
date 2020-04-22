using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class RoomModel : IValidatableObject
    {
        [Required(ErrorMessage = "The RoomId is required")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Name should be alphanumeric")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Type is required")]
        public RoomTypeModel Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
