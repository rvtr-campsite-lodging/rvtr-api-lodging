using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RVTR.Lodging.ObjectModel.Models
{
    public class ReviewModel : IValidatableObject
    {
        /// <summary>
        /// Id of Review.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The ReviewId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "The ReviewId number cannot be negative")]
        public int ReviewId { get; set; }
        /// <summary>
        /// Id from User of Review.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The UserId is required")]
        public int UserId { get; set; }
        /// <summary>
        /// Id from Hotel of Review.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The HotelId is required")]
        public int HotelId { get; set; }
        /// <summary>
        /// Username of Review.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The UserName is required")]
        public string UserName { get; set; }
        /// <summary>
        /// Rating of Review. Must be between 1 and 5.
        /// </summary>
        /// <value></value>
        [Required(ErrorMessage = "The Rating is required")]
        [Range(1, 5, ErrorMessage = "The Rating should be an integer between 1 & 5 ")]
        public int Rating { get; set; }
        /// <summary>
        /// Text Content of Review.
        /// </summary>
        /// <value></value>
        public string Content { get; set; }
        /// <summary>
        /// Date of Review.
        /// </summary>
        /// <value></value>
        public DateTime Date { get; set; }
        /// <summary>
        /// Hotel of Review
        /// </summary>
        /// <value></value>
        public HotelModel Hotel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          return Enumerable.Empty<ValidationResult>();
        }

        /// <summary>
        /// Used to get Date for Review.
        /// </summary>
        public ReviewModel()
        {
            Date = DateTime.Now;
        }
    }
}
