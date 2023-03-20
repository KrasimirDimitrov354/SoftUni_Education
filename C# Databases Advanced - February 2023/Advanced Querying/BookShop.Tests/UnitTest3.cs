using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using BookShop;
using BookShop.Data;
using BookShop.Models;
using BookShop.Models.Enums;
using BookShop.Initializer;

[TestFixture]
public class Test_003_000_001
{
    private IServiceProvider serviceProvider;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<BookShopContext>()
            .UseInMemoryDatabase(databaseName: "BookShop")
            .Options;

        var services = new ServiceCollection()
            .AddDbContext<BookShopContext>(b => b.UseInMemoryDatabase("BookShop"));

        serviceProvider = services.BuildServiceProvider();
    }

    [Test]
    public void ValidateOutput()
    {
        var service = serviceProvider.GetService<BookShopContext>();
        DbInitializer.Seed(service);

        var assertService = serviceProvider.GetService<BookShopContext>();

        string result = StartUp.GetGoldenBooks(assertService).Trim();

        Assert.AreEqual(285, result.Length, $"Returned value is incorrect!");
    }
}