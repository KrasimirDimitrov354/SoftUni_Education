namespace SplittingText.Controllers;

using Microsoft.AspNetCore.Mvc;

using ViewModels;

public class HomeController : Controller
{
    public IActionResult Index(SplittingTextViewModel viewModel)
    {
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Split(SplittingTextViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return this.RedirectToAction("Index", viewModel);
        }

        string[] textToSplit = viewModel
            .TextToSplit
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        string output = String.Join(Environment.NewLine, textToSplit);
        viewModel.SplitText = output;
        
        return this.RedirectToAction("Index", viewModel);
    }
}