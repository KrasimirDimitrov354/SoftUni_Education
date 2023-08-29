namespace SoftUniBazar.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Ad
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    [Required]
    [ForeignKey(nameof(Owner))]
    public string OwnerId { get; set; } = null!;
    public virtual BazaarUser Owner { get; set; } = null!;

    [ForeignKey(nameof(Buyer))]
    public string? BuyerId { get; set; }
    public virtual BazaarUser? Buyer { get; set; }

    [Required]
    public string ImageUrl { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
