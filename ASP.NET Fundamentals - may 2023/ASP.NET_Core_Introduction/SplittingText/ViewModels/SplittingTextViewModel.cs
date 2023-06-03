namespace SplittingText.ViewModels;

using System.ComponentModel.DataAnnotations;

public class SplittingTextViewModel
{
    [Required]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Text must be a string with a minimum length of 2 symbols and maximum length of 30 symbols.")]
    public string TextToSplit { get; set; }

    public string? SplitText { get; set; }
}
