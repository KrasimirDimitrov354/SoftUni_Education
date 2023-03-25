namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Product
{
    public Product()
    {
        CategoriesProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.ProductNameType)]
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? BuyerId { get; set; }
    public virtual User? Buyer { get; set; }

    public int SellerId { get; set; }
    public virtual User Seller { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
}
