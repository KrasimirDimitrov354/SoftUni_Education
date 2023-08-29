namespace SoftUniBazar.Services.Interfaces;

using SoftUniBazar.ViewModels.Category;

public interface ICategoryService
{
    Task<IEnumerable<CategorySelectViewModel>> GetCategoriesForSelectAsync();

    Task<bool> CategoryExistsByIdAsync(int categoryId);
}
