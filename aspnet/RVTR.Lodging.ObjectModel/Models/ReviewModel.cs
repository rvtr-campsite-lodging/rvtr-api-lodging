using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class ReviewModel : IValidatableObject
    {
        [Required(ErrorMessage = "The ReviewId is required")]
        public int ReviewId { get; set; }
        [Required(ErrorMessage = "The UserId is required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "The HotelId is required")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "The UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Rating is required")]
        [Range(1, 5, ErrorMessage = "The Rating should be an integer between 1 & 5 ")]
        public int Rating { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "The Hotel is required")]
        public HotelModel Hotel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          return Enumerable.Empty<ValidationResult>();
        }
        public ReviewModel()
        {
            Date = DateTime.Now;
        }
    }
}
