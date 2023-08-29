namespace SoftUniBazar.Services;

using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SoftUniBazar.Data;
using SoftUniBazar.Models;
using SoftUniBazar.ViewModels.Ad;
using SoftUniBazar.Services.Interfaces;

public class AdService : IAdService
{
    private readonly BazarDbContext dbContext;

    public AdService(BazarDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<AdPreviewViewModel>> GetAdsForPreviewAsync()
    {
        IEnumerable<AdPreviewViewModel> allAds = await dbContext.Ads
            .Include(a => a.Category)
            .Include(a => a.Owner)
            .Select(a => new AdPreviewViewModel()
            {
                Id = a.Id,
                Name = a.Name,
                ImageUrl = a.ImageUrl,
                CreatedOn = a.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Category = a.Category.Name,
                Description = a.Description,
                Price = a.Price.ToString(),
                Owner = a.Owner.UserName
            })
            .ToArrayAsync();

        return allAds;
    }

    public async Task AddAdAsync(AdFormViewModel viewModel, string userId)
    {
        Ad ad = new Ad()
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            ImageUrl = viewModel.ImageUrl,
            Price = viewModel.Price,
            CategoryId = viewModel.CategoryId,
            OwnerId = userId
        };

        await dbContext.Ads.AddAsync(ad);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> AdExistsByIdAsync(int adId)
    {
        return await dbContext.Ads.AnyAsync(a => a.Id == adId);
    }

    public async Task<bool> AdIsOwnedByUserAsync(int adId, string userId)
    {
        return await dbContext.Ads.AnyAsync(a => a.Id == adId && a.OwnerId == userId);
    }

    public async Task<AdFormViewModel> GetAdForEditByIdAsync(int adId)
    {
        AdFormViewModel adToEdit = await dbContext.Ads
            .Where(a => a.Id == adId)
            .Select(a => new AdFormViewModel()
            {
                Name = a.Name,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                Price = a.Price,
                CategoryId = a.CategoryId
            })
            .FirstAsync();

        return adToEdit;
    }

    public async Task EditAddAsync(AdFormViewModel viewModel, int adId)
    {
        Ad adToEdit = await dbContext.Ads.FirstAsync(a => a.Id == adId);

        adToEdit.Name = viewModel.Name;
        adToEdit.Description = viewModel.Description;
        adToEdit.ImageUrl = viewModel.ImageUrl;
        adToEdit.Price = viewModel.Price;
        adToEdit.CategoryId = viewModel.CategoryId;

        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<AdPreviewViewModel>> GetAllAdsInUserCartAsync(string userId)
    {
        IEnumerable<AdPreviewViewModel> allAdsInCart = await dbContext.AdsBuyers
            .Include(ab => ab.Ad)
            .ThenInclude(a => a.Category)
            .Where(ab => ab.BuyerId == userId)
            .Select(ab => new AdPreviewViewModel()
            {
                Id = ab.Ad.Id,
                Name = ab.Ad.Name,
                ImageUrl = ab.Ad.ImageUrl,
                CreatedOn = ab.Ad.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Category = ab.Ad.Category.Name,
                Description = ab.Ad.Description,
                Price = ab.Ad.Price.ToString()
            })
            .ToArrayAsync();

        return allAdsInCart;
    }

    public async Task<bool> AdIsAlreadyInUserCartAsync(int adId, string userId)
    {
        return await dbContext.AdsBuyers.AnyAsync(a => a.AdId == adId && a.BuyerId == userId);
    }

    public async Task AddAdToUserCartAsync(int adId, string userId)
    {
        dbContext.AdsBuyers.Add(new AdBuyer
        {
            AdId = adId,
            BuyerId = userId
        });

        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveAdFromUserCartAsync(int adId, string userId)
    {
        AdBuyer adBuyer = await dbContext.AdsBuyers
            .FirstAsync(a => a.AdId == adId && a.BuyerId == userId);

        dbContext.AdsBuyers.Remove(adBuyer);
        await dbContext.SaveChangesAsync();
    }
}
