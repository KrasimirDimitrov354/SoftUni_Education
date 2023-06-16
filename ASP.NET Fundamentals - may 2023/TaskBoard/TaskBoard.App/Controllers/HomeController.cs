namespace TaskBoard.App.Controllers;

using Microsoft.AspNetCore.Mvc;

using Extensions;
using Service.Interfaces;
using TaskBoard.Web.ViewModels.Home;

public class HomeController : Controller
{
    private readonly IHomeService homeService;

    public HomeController(IHomeService homeService)
    {
        this.homeService = homeService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            string currentUser = User.GetId();

            DisplayTasksViewModel tasksToDisplay = await homeService.DisplayAllTasksAsync(currentUser, User.Identity.Name);
            return View(tasksToDisplay);
        }

        return View();
    }
}