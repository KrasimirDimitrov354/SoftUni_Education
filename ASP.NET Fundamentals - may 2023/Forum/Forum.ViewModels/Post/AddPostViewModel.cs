namespace Forum.ViewModels.Post;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidations.Post;

public class AddPostViewModel
{
    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = InvalidTitleMessage)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = InvalidContentMessage)]
    public string Content { get; set; } = null!;
}
