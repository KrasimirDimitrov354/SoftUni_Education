namespace ProductShop;

using AutoMapper;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;
using DTOs.Import;
//using DTOs.Export;

public class StartUp
{
    static void Main()
    {
        var shopContext = new ProductShopContext();

        //1. Import Users
        //string usersJson = File.ReadAllText(@"../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(shopContext, usersJson));

        //2. Import Products
        //string productsJson = File.ReadAllText(@"../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(shopContext, productsJson));

        //3. Import Categories
        //string categoriesJson = File.ReadAllText(@"../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(shopContext, categoriesJson));

        //4. Import Categories and Products
        //string cpJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(shopContext, cpJson));

        //5. Export Products in Range
        //Console.WriteLine(GetProductsInRange(shopContext));

        //6. Export Sold Products
        //Console.WriteLine(GetSoldProducts(shopContext));

        //7. Export Categories by Products Count
        //Console.WriteLine(GetCategoriesByProductsCount(shopContext));

        //8. Export Users and Products
        //Console.WriteLine(GetUsersWithProducts(shopContext));
    }

    private static IMapper CreateMapper()
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        return mapper;
    }

    //1. Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var userDTOs = JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);
        ICollection<User> validUsers = new HashSet<User>();

        foreach (var userDTO in userDTOs!)
        {
            User user = mapper.Map<User>(userDTO);
            validUsers.Add(user);
        }

        context.Users.BulkInsert(validUsers);

        return $"Successfully imported {validUsers.Count}";
    }

    //2. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var productDTOs = JsonConvert.DeserializeObject<ImportProductDTO[]>(inputJson);
        ICollection<Product> validProducts = new HashSet<Product>();

        foreach (var productDTO in productDTOs!)
        {
            Product product = mapper.Map<Product>(productDTO);
            validProducts.Add(product);
        }

        context.Products.BulkInsert(validProducts);

        return $"Successfully imported {validProducts.Count}";
    }

    //3. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var categoryDTOs = JsonConvert.DeserializeObject<ImportCategoryDTOs[]>(inputJson);
        ICollection<Category> validCategories = new HashSet<Category>();

        foreach (var categoryDTO in categoryDTOs!)
        {
            Category category = mapper.Map<Category>(categoryDTO);

            if (category.Name != null)
            {
                validCategories.Add(category);
            }
        }

        context.Categories.BulkInsert(validCategories);

        return $"Successfully imported {validCategories.Count}";
    }

    //4. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        var mapper = CreateMapper();

        var cpDTOs = JsonConvert.DeserializeObject<ImportCategoryProductDTO[]>(inputJson);
        ICollection<CategoryProduct> categoriesProducts = new HashSet<CategoryProduct>();

        foreach (var cpDTO in cpDTOs!)
        {
            CategoryProduct cp = mapper.Map<CategoryProduct>(cpDTO);
            categoriesProducts.Add(cp);
        }

        context.CategoriesProducts.BulkInsert(categoriesProducts);

        return $"Successfully imported {categoriesProducts.Count}";
    }

    //5. Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .AsNoTracking()
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new
            {
                name = p.Name,
                price = p.Price,
                seller = p.Seller.FirstName + " " + p.Seller.LastName
            })
            .ToArray();

        return JsonConvert.SerializeObject(products, Formatting.Indented);
    }

    //6. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var sellersWithOneOrMoreItemsSold = context.Users
            .AsNoTracking()
            .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                soldProducts = u.ProductsSold
                               .Where(p => p.BuyerId.HasValue)
                               .Select(p => new
                               {
                                   name = p.Name,
                                   price = p.Price,
                                   buyerFirstName = p.Buyer!.FirstName,
                                   buyerLastName = p.Buyer!.LastName
                               })
                               .ToArray()
            })
            .ToArray();

        return JsonConvert.SerializeObject(sellersWithOneOrMoreItemsSold, Formatting.Indented);
    }

    //7. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .AsNoTracking()
            .OrderByDescending(c => c.CategoriesProducts.Count)
            .Select(c => new
            {
                category = c.Name,
                productsCount = c.CategoriesProducts.Count,
                averagePrice = c.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                totalRevenue = c.CategoriesProducts.Sum(cp => cp.Product.Price).ToString("f2")
            })
            .ToArray();

        return JsonConvert.SerializeObject(categories, Formatting.Indented);
    }

    //8. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var usersAndSoldProducts = context.Users
                    .AsNoTracking()
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId.HasValue))
                    //.ProjectTo<SellerDTO>(mapper.ConfigurationProvider)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold
                                .Count(p => p.BuyerId.HasValue),
                            products = u.ProductsSold
                                .Where(p => p.Buyer != null)
                                .Select(p => new
                                {
                                    name = p.Name,
                                    price = Math.Round(p.Price, 2)
                                })
                                .ToArray()
                        }
                    })
                    .OrderByDescending(u => u.soldProducts.count)
                    .ToArray();

        var usersCount = new
        {
            usersCount = usersAndSoldProducts.Length,
            users = usersAndSoldProducts
        };

        return JsonConvert.SerializeObject(usersCount,
            Formatting.Indented,
            new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
    }
}
