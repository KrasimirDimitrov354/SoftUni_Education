namespace SoftUniBazar.ViewModels.Ad;

using SoftUniBazar.ViewModels.Category;
using System.ComponentModel.DataAnnotations;

public class AdFormViewModel
{
    public AdFormViewModel()
    {
        Categories = new HashSet<CategorySelectViewModel>();
    }

    [Required]
    [StringLength(25, MinimumLength = 5)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(250, MinimumLength = 15)]
    public string Description { get; set; } = null!;

    [Required]
    [Display(Name = "Image URL")]
    public string ImageUrl { get; set; } = null!;

    public decimal Price { get; set; }

    [Required]
    [Display(Name = "Category")]
    public int CategoryId { get; set; }

    public virtual IEnumerable<CategorySelectViewModel> Categories { get; set; }
}
