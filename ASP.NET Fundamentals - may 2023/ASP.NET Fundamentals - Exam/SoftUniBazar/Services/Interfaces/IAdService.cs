namespace SoftUniBazar.Services.Interfaces;

using SoftUniBazar.ViewModels.Ad;

public interface IAdService
{
    Task<IEnumerable<AdPreviewViewModel>> GetAdsForPreviewAsync();

    Task AddAdAsync(AdFormViewModel viewModel, string userId);

    Task<bool> AdExistsByIdAsync(int adId);

    Task<bool> AdIsOwnedByUserAsync(int adId, string userId);

    Task<AdFormViewModel> GetAdForEditByIdAsync(int adId);

    Task EditAddAsync(AdFormViewModel viewModel, int adId);

    Task<IEnumerable<AdPreviewViewModel>> GetAllAdsInUserCartAsync(string userId);

    Task<bool> AdIsAlreadyInUserCartAsync(int adId, string userId);

    Task AddAdToUserCartAsync(int adId, string userId);

    Task RemoveAdFromUserCartAsync(int adId, string userId);
}
