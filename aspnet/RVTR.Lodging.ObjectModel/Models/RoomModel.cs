using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class RoomModel : IValidatableObject
    {
        /**
        * Represents a room object that has an identifier, name, and the type of room it is (single bed, 4-person room, etc).
        *
        * ```yaml
        * roomId: int;
        * name: string;
        * type: RoomType;
        * ```
        */
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
