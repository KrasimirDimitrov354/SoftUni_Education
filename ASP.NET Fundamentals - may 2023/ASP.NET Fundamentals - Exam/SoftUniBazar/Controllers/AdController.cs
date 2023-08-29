namespace SoftUniBazar.Controllers;

using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using SoftUniBazar.ViewModels.Ad;
using SoftUniBazar.Services.Interfaces;

public class AdController : BaseController
{
    private readonly IAdService adService;
    private readonly ICategoryService categoryService;

    public AdController(IAdService adService, ICategoryService categoryService)
    {
        this.adService = adService;
        this.categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<AdPreviewViewModel> allAds = await adService.GetAdsForPreviewAsync();
        return View(allAds);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        AdFormViewModel viewModel = new AdFormViewModel();
        viewModel.Categories = await categoryService.GetCategoriesForSelectAsync();

        return View(viewModel);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AdFormViewModel viewModel)
    {
        bool categoryExists = await categoryService.CategoryExistsByIdAsync(viewModel.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(nameof(viewModel.CategoryId), "Selected category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            viewModel.Categories = await categoryService.GetCategoriesForSelectAsync();
            return View(viewModel);
        }

        try
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await adService.AddAdAsync(viewModel, userId);

            return RedirectToAction("All", "Ad");
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occured while adding your ad, please try again or contact administrator.");

            viewModel.Categories = await categoryService.GetCategoriesForSelectAsync();
            return View(viewModel);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        bool adExists = await adService.AdExistsByIdAsync(id);
        if (!adExists)
        {
            return RedirectToAction("All", "Ad");
        }

        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        bool adIsOwnedByUser = await adService.AdIsOwnedByUserAsync(id, userId);
        if (!adIsOwnedByUser)
        {
            return RedirectToAction("All", "Ad");
        }

        try
        {
            AdFormViewModel adToEdit = await adService.GetAdForEditByIdAsync(id);
            adToEdit.Categories = await categoryService.GetCategoriesForSelectAsync();

            return View(adToEdit);
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Ad");
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(int id, AdFormViewModel adToEdit)
    {
        bool adExists = await adService.AdExistsByIdAsync(id);
        if (!adExists)
        {
            return RedirectToAction("All", "Ad");
        }

        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        bool adIsOwnedByUser = await adService.AdIsOwnedByUserAsync(id, userId);
        if (!adIsOwnedByUser)
        {
            return RedirectToAction("All", "Ad");
        }

        bool categoryExists = await categoryService.CategoryExistsByIdAsync(adToEdit.CategoryId);
        if (!categoryExists)
        {
            ModelState.AddModelError(nameof(adToEdit.CategoryId), "Selected category does not exist.");
        }

        if (!ModelState.IsValid)
        {
            adToEdit.Categories = await categoryService.GetCategoriesForSelectAsync();
            return View(adToEdit);
        }

        try
        {
            await adService.EditAddAsync(adToEdit, id);

            return RedirectToAction("All", "Ad");
        }
        catch (Exception)
        {
            ModelState.AddModelError(string.Empty, "Unexpected error occured while editing your ad, please try again or contact administrator.");

            adToEdit.Categories = await categoryService.GetCategoriesForSelectAsync();
            return View(adToEdit);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Cart()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        IEnumerable<AdPreviewViewModel> allAdsInCart = await adService.GetAllAdsInUserCartAsync(userId);
        return View(allAdsInCart);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        bool adExists = await adService.AdExistsByIdAsync(id);
        if (!adExists)
        {
            return RedirectToAction("All", "Ad");
        }

        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        bool adIsOwnedByUser = await adService.AdIsOwnedByUserAsync(id, userId);
        if (adIsOwnedByUser)
        {
            return RedirectToAction("All", "Ad");
        }

        bool adIsInUserCart = await adService.AdIsAlreadyInUserCartAsync(id, userId);
        if (adIsInUserCart)
        {
            return RedirectToAction("All", "Ad");
        }

        try
        {
            await adService.AddAdToUserCartAsync(id, userId);
            return RedirectToAction("Cart", "Ad");
        }
        catch (Exception)
        {
            return RedirectToAction("All", "Ad");
        }
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        bool adExists = await adService.AdExistsByIdAsync(id);
        if (!adExists)
        {
            return RedirectToAction("All", "Ad");
        }

        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        bool adIsOwnedByUser = await adService.AdIsOwnedByUserAsync(id, userId);
        if (adIsOwnedByUser)
        {
            return RedirectToAction("All", "Ad");
        }

        bool adIsInUserCart = await adService.AdIsAlreadyInUserCartAsync(id, userId);
        if (!adIsInUserCart)
        {
            return RedirectToAction("Cart", "Ad");
        }

        try
        {
            await adService.RemoveAdFromUserCartAsync(id, userId);          
        }
        catch (Exception)
        {

        }

        return RedirectToAction("All", "Ad");
    }
}
