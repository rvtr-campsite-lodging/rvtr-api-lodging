using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace RVTR.Lodging.ObjectModel.Models
{
    public class BedModel : IValidatableObject
    {
        /// <summary>
        /// Id of Bed.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The BedId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The BedId number cannot be negative")]
        public int BedId { get; set; }
        /// <summary>
        /// Size of the Bed which can be King, Queen, Full, and Twin.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Size is required")]
        public string Size { get; set; }
        [Required(ErrorMessage = "The Amount is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The Amount should be positive")]
        /// <summary>
        /// Number of Beds.
        /// </summary>
        /// <value></value>
        public int NumberOfBeds { get; set; }

        /// <summary>
        /// Validates that Size is one of four valid strings.
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!Size.Equals("King") && !Size.Equals("Queen") && !Size.Equals("Full") && !Size.Equals("Twin"))
            {
                yield return new ValidationResult("the bed size must be King, Queen, Full, or Twin", new[] { "Size" });
            }

        }

    }
}
