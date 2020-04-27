using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace RVTR.Lodging.ObjectModel.Models
{
    /// <summary>
    /// Represents an image object
    /// </summary>
    public class ImageModel : IValidatableObject
    {
        /// <summary>
        /// Id of Image.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The ImageId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The ImageId number cannot be negative")]
        public int Id { get; set; }
        /// <summary>
        /// URL to the blob of image.
        /// </summary>
        /// <value></value>
        /// [Required(ErrorMessage = "The BlobUrl is required")]
        [Url(ErrorMessage = "The BlobUrl is not of type Url")]
        public string BlobUrl { get; set; }
        /// <summary>
        /// Validates that the BlobUrl is an image.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!BlobUrl.Contains(".jpg") && !BlobUrl.Contains(".png") && !BlobUrl.Contains(".gif") && !BlobUrl.Contains(".jpeg"))
            {
                yield return new ValidationResult("Url must be for an image (.jpg, .jpeg, .png, or .gif)", new[] { nameof(BlobUrl) });
            }
        }
    }
}
