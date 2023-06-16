namespace TaskBoard.Web.ViewModels.Task;

using System.ComponentModel.DataAnnotations;

using Board;

using static Common.EntityFieldValidation.Task;

public class TaskFormViewModel
{
    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLengthErrorMessage)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLengthErrorMessage)]
    public string Description { get; set; } = null!;

    [Display(Name = "Board")]
    public int BoardId { get; set; }

    public IEnumerable<BoardDropdownSelectViewModel>? Boards { get; set; }
}
