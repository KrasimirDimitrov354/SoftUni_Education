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

    public async Task<IEnumerable<ListPostViewModel>> ListAllAsync()
    {
        IEnumerable<ListPostViewModel> allPosts = await dbContext.Posts
            .Select(p => new ListPostViewModel() 
            { 
                Id = p.Id.ToString(),
                Title = p.Title,
                Content = p.Content 
            })
            .ToArrayAsync();

        return allPosts;
    }

    public async Task AddPostAsync(AddPostViewModel viewModel)
    {
        Post newPost = new Post()
        {
            Title = viewModel.Title,
            Content = viewModel.Content
        };

        await dbContext.Posts.AddAsync(newPost);
        await dbContext.SaveChangesAsync();
    }
}