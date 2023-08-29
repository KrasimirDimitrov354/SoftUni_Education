namespace SoftUniBazar.Services;

using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using SoftUniBazar.Data;
using SoftUniBazar.Services.Interfaces;
using SoftUniBazar.ViewModels.Category;

public class CategoryService : ICategoryService
{
    private readonly BazarDbContext dbContext;

    public CategoryService(BazarDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<CategorySelectViewModel>> GetCategoriesForSelectAsync()
    {
        IEnumerable<CategorySelectViewModel> allCategories = await dbContext.Categories
            .Select(c => new CategorySelectViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToArrayAsync();

        return allCategories;
    }

    public async Task<bool> CategoryExistsByIdAsync(int categoryId)
    {
        return await dbContext.Categories.AnyAsync(c => c.Id == categoryId);
    }
}
