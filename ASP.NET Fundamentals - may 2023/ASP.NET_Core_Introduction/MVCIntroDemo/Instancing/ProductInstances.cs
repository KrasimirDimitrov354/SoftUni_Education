namespace MVCIntroDemo.Instancing;

using ViewModels.Product;

public static class ProductInstances
{
    public static IEnumerable<ProductViewModel> products = new List<ProductViewModel>
    {
        new ProductViewModel
        {
            Id = Guid.NewGuid(),
            Name = "Cheese",
            Price = 7.00m
        },
        new ProductViewModel
        {
            Id = Guid.NewGuid(),
            Name = "Ham",
            Price = 5.50m
        },
        new ProductViewModel
        {
            Id = Guid.NewGuid(),
            Name = "Bread",
            Price = 1.00m
        }
    };
}
