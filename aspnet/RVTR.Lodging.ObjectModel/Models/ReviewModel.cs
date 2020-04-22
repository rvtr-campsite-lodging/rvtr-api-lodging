using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  public class ReviewModel : IValidatableObject
  {
    public int ReviewId { get; set; }
    public int UserId { get; set; }
    public int HotelId { get; set; }
    public string UserName { get; set; }
    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    public HotelModel Hotel { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => throw new System.NotImplementedException();

    public ReviewModel()
    {
      Date = DateTime.Now;
    }
  }
}
