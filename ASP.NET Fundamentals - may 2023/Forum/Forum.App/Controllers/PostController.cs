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
        IEnumerable<DisplayPostViewModel> allPosts = await postService.ListAllAsync();
        return View(allPosts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ModifyPostViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        try
        {
            await postService.AddPostAsync(viewModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, AddingPostExceptionMessage);
            return View(viewModel);
        }

        return RedirectToAction("All", "Post");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        try
        {
            ModifyPostViewModel postToModify = await postService.GetByIdAsync(id);
            return View(postToModify);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(string id, ModifyPostViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        try
        {
            await postService.EditByIdAsync(id, viewModel);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, EditingPostExceptionMessage);
            return View(viewModel);
        }

        return RedirectToAction("All", "Post");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            ModifyPostViewModel postToModify = await postService.GetByIdAsync(id);
            return View(postToModify);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Post");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id, ModifyPostViewModel viewModel)
    {
        try
        {
            await postService.DeleteByIdAsync(id);
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, DeletingPostExceptionMessage);
            return View(viewModel);
        }

        return RedirectToAction("All", "Post");
    }
}
