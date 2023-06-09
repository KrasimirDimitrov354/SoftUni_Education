namespace Forum.Services.Interfaces;

using ViewModels.Post;

public interface IPostService
{
    Task<IEnumerable<ListPostViewModel>> ListAllAsync();

    Task AddPostAsync(AddPostViewModel viewModel);
}
