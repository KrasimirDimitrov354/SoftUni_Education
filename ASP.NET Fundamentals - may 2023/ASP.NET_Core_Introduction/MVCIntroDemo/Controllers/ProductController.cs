namespace MVCIntroDemo.Controllers;

using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using static Instancing.ProductInstances;

public class ProductController : Controller
{
    [ActionName("All-Products")]
    public IActionResult All(string keyword)
    {
        if (String.IsNullOrWhiteSpace(keyword))
        {
            return View(products);
        }

        var productsAfterSearch = products
            .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
            .ToArray();

        if (productsAfterSearch.Any())
        {
            return View(productsAfterSearch);
        }
        else
        {
            return this.RedirectToAction("NoProductsFound");
        } 
    }

    [Route("/Product/Details/{id}")]
    public IActionResult ById(string id)
    {
        var soughtProduct = products
            .Where(p => p.Id.ToString() == id)
            .FirstOrDefault();

        if (soughtProduct == null)
        {
            return this.RedirectToAction("NoProductsFound");
        }

        return View(soughtProduct);
    }

    public IActionResult NoProductsFound()
    {
        return View();
    }

    public IActionResult AllAsJson()
    {
        return Json(products,
            new JsonSerializerOptions
            {
                WriteIndented = true 
            });
    }

    public IActionResult DownloadProducts()
    {
        var output = new StringBuilder();
        var productsArray = products.ToArray();

        for (int i = 0; i < productsArray.Length; i++)
        {
            output.AppendLine($"Product {i + 1}: {productsArray[i].Name} - {productsArray[i].Price} lv.");
        }

        Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

        return File(Encoding.UTF8.GetBytes(output.ToString()), "text/plain");
    }
}
