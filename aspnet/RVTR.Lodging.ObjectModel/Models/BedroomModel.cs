using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RVTR.Lodging.ObjectModel.Models
{
  /// <summary>
  /// Represents the _Bedroom_ model
  /// </summary>
  public class BedroomModel : IValidatableObject
  {
    public int Id { get; set; }
    public int Count { get; set; }
    public string BedroomType { get; set; }
    /// <summary>
    /// Represents the _Bedroom_ `Validate` method
    /// </summary>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new List<ValidationResult>();
  }
}
