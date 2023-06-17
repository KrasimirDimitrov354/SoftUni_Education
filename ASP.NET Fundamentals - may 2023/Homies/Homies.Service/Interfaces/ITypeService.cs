using Homies.Web.ViewModels.Type;

namespace Homies.Service.Interfaces;

public interface ITypeService
{
    Task<IEnumerable<TypeDropdownSelectViewModel>> DisplayAllTypesDropdownSelectAsync();

    Task<bool> ExistsByIdAsync(int typeId);
}
