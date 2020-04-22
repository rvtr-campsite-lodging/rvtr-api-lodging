using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class ImageModel : IValidatableObject
    {
        [Required(ErrorMessage = "The ImageId is required")]
        public int ImageId { get; set; }
        [Required(ErrorMessage = "The BlobUrl is required")]
        [Url(ErrorMessage = "The BlobUrl is not of type Url")]
        public string BlobUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext){
            return Enumerable.Empty<ValidationResult>();
        }
    }
}
