namespace Homies.Web.ViewModels.Event;

using System.ComponentModel.DataAnnotations;

using Homies.Web.ViewModels.Type;

using static Common.EntityFieldValidation.Event;

public class EventFormViewModel
{
    [Required]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public string Description { get; set; } = null!;

    [Required]
    public string Start { get; set; } = null!;

    [Required]
    public string End { get; set; } = null!;

    [Required]
    public int TypeId { get; set; }

    public IEnumerable<TypeDropdownSelectViewModel>? Types { get; set; }
}
