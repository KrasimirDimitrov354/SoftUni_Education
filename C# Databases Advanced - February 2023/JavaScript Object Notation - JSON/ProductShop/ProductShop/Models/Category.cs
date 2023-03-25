namespace ProductShop.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Category
{
    public Category()
    {
        CategoriesProducts = new HashSet<CategoryProduct>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.CategoryNameType)]
    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryProduct> CategoriesProducts { get; set; }
}
