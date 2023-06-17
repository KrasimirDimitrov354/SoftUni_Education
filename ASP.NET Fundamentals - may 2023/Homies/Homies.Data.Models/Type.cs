namespace Homies.Data.Models;

using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

using static Homies.Common.EntityFieldValidation.Event;
using static Homies.Common.EntityColumnInformation.Event;

public class Type
{
    [Required]
    [Comment(IdComment)]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Comment(NameComment)]
    public string Name { get; set; } = null!;

    public ICollection<Event> Events { get; set; } = new HashSet<Event>();
}
