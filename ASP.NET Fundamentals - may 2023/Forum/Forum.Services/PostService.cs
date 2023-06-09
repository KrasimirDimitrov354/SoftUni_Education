namespace Forum.Services;

using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using Data;
using Interfaces;
using Data.Models;
using ViewModels.Post;

public class PostService : IPostService
{
    private readonly ForumDbContext dbContext;

    public PostService(ForumDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<DisplayPostViewModel>> ListAllAsync()
    {
        IEnumerable<DisplayPostViewModel> allPosts = await dbContext.Posts
            .Select(p => new DisplayPostViewModel() 
            { 
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content 
            })
            .ToArrayAsync();

        return allPosts;
    }

    public async Task AddPostAsync(ModifyPostViewModel viewModel)
    {
        Post newPost = new Post()
        {
            Title = viewModel.Title,
            Content = viewModel.Content
        };

        await dbContext.Posts.AddAsync(newPost);
        await dbContext.SaveChangesAsync();
    }

    public async Task<ModifyPostViewModel> GetByIdAsync(string id)
    {
        Post postToModify = await GetPostFromDbAsync(id);

        return new ModifyPostViewModel()
        {
            Title = postToModify.Title,
            Content = postToModify.Content
        };
    }

    public async Task EditByIdAsync(string id, ModifyPostViewModel viewModel)
    {
        Post postToEdit = await GetPostFromDbAsync(id);

        postToEdit.Title = viewModel.Title;
        postToEdit.Content = viewModel.Content;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(string id)
    {
        Post postToDelete = await GetPostFromDbAsync(id);

        dbContext.Posts.Remove(postToDelete);
        await dbContext.SaveChangesAsync();
    }

    private async Task<Post> GetPostFromDbAsync(string id)
    {
        return await dbContext.Posts.FirstAsync(p => p.Id.ToString().Equals(id));
    }
}