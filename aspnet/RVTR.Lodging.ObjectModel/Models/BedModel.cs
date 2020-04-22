using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace RVTR.Lodging.ObjectModel.Models
{
    public class BedModel : IValidatableObject
    {


        [Required(ErrorMessage = "The BedId is required")]
        public int BedId { get; set; }
        [Required(ErrorMessage = "The Size is required")]
        public string Size { get; set; }
        [Required(ErrorMessage = "The Amount is required")]
        public decimal Amount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!Size.Equals("King") || !Size.Equals("Queen") || !Size.Equals("Full") || !Size.Equals("Twin"))
            {
                yield return new ValidationResult("the bed size must be King, Queen, Full, or Twin", new[] { "Size" });
            }

            if (Decimal.Compare(Amount, 0.00m) <= 0)
            {
                yield return new ValidationResult("the amount must be greater than zero", new[] { "Amount" });
            }
        }

    }
}
