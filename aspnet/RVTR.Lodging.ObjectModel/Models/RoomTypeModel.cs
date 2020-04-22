using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class RoomTypeModel : IValidatableObject
    {
        [Required(ErrorMessage = "The RoomId is required")]
        public int RoomTypeId { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "The Name should be alphanumeric")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Beds list is required")]
        public List<BedModel> Beds { get; set; }
        [Required(ErrorMessage = "The Bathrooms number amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Bathrooms number amount cannot be negative or 0")]
        public double Bathrooms { get; set; }
        [Required(ErrorMessage = "The Bedrooms number amount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The Bedrooms number amount cannot be negative")]
        public double Bedrooms { get; set; }
        [Required(ErrorMessage = "The BaseCapacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The BaseCapacity cannot be negative or 0")]
        public int BaseCapacity { get; set; }
        [Required(ErrorMessage = "The MaxCpacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The MaxCapacity cannot be negative or 0")]
        public int MaxCapacity { get; set; }
        [Required(ErrorMessage = "The PricePerNight is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The PricePerNight cannot be negative or 0")]
        public int PricePerNight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "The PricePerAdditionalPerson cannot be negative or 0")]
        public int PricePerAdditionalPerson { get; set; }
        public string Description { get; set; }
        public List<ImageModel> Images { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Beds.Count == 0)
            {
                yield return new ValidationResult("The Beds list must contain at least one bed", new[] { "Beds" });
            }
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
