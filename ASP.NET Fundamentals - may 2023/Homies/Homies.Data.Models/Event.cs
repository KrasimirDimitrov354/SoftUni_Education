namespace Homies.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Homies.Common.EntityFieldValidation.Event;
using static Homies.Common.EntityColumnInformation.Event;

public class Event
{
    [Key]
    [Comment(IdComment)]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Comment(NameComment)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    [Comment(DescriptionComment)]
    public string Description { get; set; } = null!;

    [Required]
    [Comment(OrganiserIdComment)]
    public string OrganiserId { get; set; } = null!;

    [Required]
    public IdentityUser Organiser { get; set; } = null!;

    [Required]
    [Comment(CreatedOnComment)]
    public DateTime CreatedOn { get; set; }

    [Required]
    [Comment(StartComment)]
    public DateTime Start { get; set; }

    [Required]
    [Comment(EndComment)]
    public DateTime End { get; set; }

    [Required]
    [ForeignKey(nameof(Type))]
    [Comment(TypeIdComment)]
    public int TypeId { get; set; }

    [Required]
    public Type Type { get; set; } = null!;

    public ICollection<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();
}
