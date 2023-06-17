namespace Homies.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Homies.Common.EntityColumnInformation.EventParticipant;

public class EventParticipant
{
    [Required]
    [ForeignKey(nameof(Helper))]
    [Comment(HelperIdComment)]
    public string HelperId { get; set; } = null!;
    public IdentityUser Helper { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Event))]
    [Comment(EventIdComment)]
    public int EventId { get; set; }
    public Event Event { get; set; } = null!;
}
