using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Review_ model
  /// </summary>
  public class ReviewModel : IValidatableObject
  {
    public int Id { get; set; }

    [Required]
    public int AccountId { get; set; }

    [Required]
    public string Comment { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }

    [Required]
    public int Rating { get; set; }

    /// <summary>
    /// Represents the _Review_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}
