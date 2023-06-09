namespace Forum.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Forum.Common.EntityValidations.Post;
using static Forum.Common.EntityColumnComments.Post;

public class Post
{
    public Post()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    [Comment(IdComment)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    [Comment(TitleComment)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    [Comment(ContentComment)]
    public string Content { get; set; } = null!;
}