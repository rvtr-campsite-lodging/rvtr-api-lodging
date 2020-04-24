using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class LocationModel : IValidatableObject
    {
        /// <summary>
        /// Id of Location.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The LocationId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The LocationId number amount cannot be negative")]
        public int LocationId { get; set; }
        // Address number 1 of Location.
        [Required(ErrorMessage = "Address1 is required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The Address1 should be alphanumeric")]
        public string Address1 { get; set; }
        /// <summary>
        ///  Adress numbre 2 of Location.
        /// </summary>
        /// <value></value>
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The Address2 should be alphanumeric")]
        public string Address2 { get; set; }
        /// <summary>
        /// City of Location.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The City is required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The City should be alphanumeric")]
        public string City { get; set; }
        /// <summary>
        /// State of Location.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The State is requiered")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The State should be alphanumeric")]
        public string State { get; set; }
        /// <summary>
        /// Zip code of Location. Must be a 5 digit number.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Zip is required")]
        [RegularExpression(@"^[a-zA-Z0-9 ]*$", ErrorMessage = "The Zip should be alphanumeric")]
        [MinLength(5),MaxLength(5)]
        public string Zip { get; set; }
        /// <summary>
        /// Latitude of Location. Must be between -90 and 90.
        /// </summary>
        /// <value></value>
        [Range(-90, 90, ErrorMessage = "The Latitude should be between -90 and 90")]
        public double latitude { get; set; }
        /// <summary>
        /// Longitude of Location. Must be between -180 and 180.
        /// </summary>
        /// <value></value>
        [Range(-180, 180, ErrorMessage = "The Longitude should be between -180 and 180")]
        public double longitude { get; set; }
        public string CultureInfo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          List<ValidationResult> results = new List<ValidationResult>();
          if (!DoesCultureExist(CultureInfo))
          {
            results.Add(new ValidationResult("Error initializing culture"));
            return results;
          }
          results.Add(ValidationResult.Success);
          return results;
        }

        private bool DoesCultureExist(string cultureName)
        {
          return System.Globalization.CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Any(culture => string.Equals(culture.Name, cultureName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
