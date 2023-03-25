namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class User
{
    public User()
    {
        ProductsBought = new HashSet<Product>();
        ProductsSold = new HashSet<Product>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.UserFirstNameType)]
    public string? FirstName { get; set; }

    [Column(TypeName = FieldType.UserLastNameType)]
    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    [InverseProperty("Buyer")]
    public virtual ICollection<Product> ProductsBought { get; set; }

    [InverseProperty("Seller")]
    public virtual ICollection<Product> ProductsSold { get; set; }
}
