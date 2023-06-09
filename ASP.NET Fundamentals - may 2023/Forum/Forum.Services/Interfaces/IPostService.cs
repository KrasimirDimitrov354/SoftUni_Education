namespace Forum.Services.Interfaces;

using ViewModels.Post;

public interface IPostService
{
    Task<IEnumerable<DisplayPostViewModel>> ListAllAsync();

    Task AddPostAsync(ModifyPostViewModel viewModel);

    Task<ModifyPostViewModel> GetByIdAsync(string id);

    Task EditByIdAsync(string id, ModifyPostViewModel viewModel);

    Task DeleteByIdAsync(string id);
}
