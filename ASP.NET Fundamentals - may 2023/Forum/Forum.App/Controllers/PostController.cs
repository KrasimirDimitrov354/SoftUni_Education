namespace Forum.App.Controllers;

using Microsoft.AspNetCore.Mvc;

using ViewModels.Post;
using Services.Interfaces;

using static Common.EntityExceptions.Post;

public class PostController : Controller
{
    private readonly IPostService postService; 

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<ListPostViewModel> allPosts = await postService.ListAllAsync();
        return View(allPosts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddPostViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        try
        {
            await this.postService.AddPostAsync(viewModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, AddingPostException);
            return View(viewModel);
        }

        return RedirectToAction("All", "Post");
    }
}
