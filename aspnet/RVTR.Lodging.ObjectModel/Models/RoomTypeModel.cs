using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class RoomTypeModel : IValidatableObject
    {
        /// <summary>
        /// Id of RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The RoomTypeId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The RoomTypeId number amount cannot be negative")]
        public int RoomTypeId { get; set; }
        /// <summary>
        /// Name of RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The Name should be alphanumeric")]
        public string Name { get; set; }
        /// <summary>
        /// List of beds of RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Beds list is required")]
        public List<BedModel> Beds { get; set; }
        /// <summary>
        /// Number of Bathrooms in RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Bathrooms number amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Bathrooms number amount cannot be negative or 0")]
        public double Bathrooms { get; set; }
        /// <summary>
        /// Number of Bedrooms in RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Bedrooms number amount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The Bedrooms number amount cannot be negative")]
        public double Bedrooms { get; set; }
        /// <summary>
        /// Base Capacity of RoomType.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The BaseCapacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The BaseCapacity cannot be negative or 0")]
        /// <summary>
        /// Base Capacity of RoomType.
        /// </summary>
        /// <value></value>
        public int BaseCapacity { get; set; }
        [Required(ErrorMessage = "The MaxCpacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The MaxCapacity cannot be negative or 0")]
        /// <summary>
        /// Max Capacity of RoomType.
        /// </summary>
        /// <value></value>
        public int MaxCapacity { get; set; }
        [Required(ErrorMessage = "The PricePerNight is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The PricePerNight cannot be negative or 0")]
        /// <summary>
        /// Price Per Night for RoomType.
        /// </summary>
        /// <value></value>
        public int PricePerNight { get; set; }
        /// <summary>
        /// Price Per Additional Person for RoomType.
        /// </summary>
        /// <value></value>
        [Range(1, int.MaxValue, ErrorMessage = "The PricePerAdditionalPerson cannot be negative or 0")]
        public int PricePerAdditionalPerson { get; set; }
        /// <summary>
        /// Description of RoomType.
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
        /// <summary>
        /// List of Images of RoomType.
        /// </summary>
        /// <value></value>
        public List<ImageModel> Images { get; set; }

        /// <summary>
        /// Validate that Bedrooms and Bathrooms are multiples of .5.
        /// Validate that Price Per Additional Person is less than Price Per Night.
        /// Validate that Max Capacity is less than Base Capacity.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Bedrooms * 10 % 5 != 0)
            {
                yield return new ValidationResult("The Bedrooms amount must be integer or end in .5 (examples: 1, 2.5, 3.5", new[] { "Bedrooms" });
            }
            if (Bathrooms * 10 % 5 != 0)
            {
                yield return new ValidationResult("The Bathrooms amount must be integer or end in .5 (examples: 1, 2.5, 3.5", new[] { "Bathrooms" });
            }
            if (PricePerAdditionalPerson < PricePerNight)
            {
                yield return new ValidationResult("The PricePerAdditionalPerson must be greater than or equal to PricePerNight.", new[] { "PricePerAdditionalPerson" });
            }
            if (MaxCapacity < BaseCapacity)
            {
                yield return new ValidationResult("The MaxCapacity must be greater than or equal to BaseCapacity.", new[] { "MaxCapacity" });
            }
        }
    }
}
