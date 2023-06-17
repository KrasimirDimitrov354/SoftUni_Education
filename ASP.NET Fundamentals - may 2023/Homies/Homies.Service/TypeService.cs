namespace Homies.Service;

using Homies.Data;
using Homies.Service.Interfaces;
using Homies.Web.ViewModels.Type;
using Microsoft.EntityFrameworkCore;

public class TypeService : ITypeService
{
    private readonly HomiesDbContext dbContext;

    public TypeService(HomiesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<TypeDropdownSelectViewModel>> DisplayAllTypesDropdownSelectAsync()
    {
        IEnumerable<TypeDropdownSelectViewModel> allTypesDropdownSelect = await dbContext.Types
            .Select(t => new TypeDropdownSelectViewModel
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToArrayAsync();

        return allTypesDropdownSelect;
    }

    public async Task<bool> ExistsByIdAsync(int typeId)
    {
        return await dbContext.Types.AnyAsync(t => t.Id == typeId);
    }
}
