namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Seller
{
    public Seller()
    {
        this.BoardgamesSellers = new HashSet<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(FieldValidation.SellerNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(FieldValidation.SellerAddressMaxLength)]
    public string Address { get; set; } = null!;

    public string Country { get; set; } = null!;
    public string Website { get; set; } = null!;

    public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; } = null!;
}
