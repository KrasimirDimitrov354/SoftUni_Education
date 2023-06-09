namespace Forum.Data.Seeder;

using System.Collections.Generic;

using Models;

internal class PostSeeder
{
    internal Post[] GeneratePosts()
    {
        ICollection<Post> posts = new HashSet<Post>();
        Post post;

        post = new Post()
        {
            Title = "First post",
            Content = "This is the content of the first post."
        };
        posts.Add(post);

        post = new Post()
        {
            Title = "Second post",
            Content = "This is the content of the second post."
        };
        posts.Add(post);

        post = new Post()
        {
            Title = "Third post",
            Content = "This is the content of the third post."
        };
        posts.Add(post);

        return posts.ToArray();
    }
}
