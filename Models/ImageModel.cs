using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class ImageModel : IValidatableObject
  {
    [Key]
    public int ImageId { get; set; }

    [Required]
    [Url]
    public string BlobUrl { get; set; }

    public ImageModel() {}

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();
  }
}
