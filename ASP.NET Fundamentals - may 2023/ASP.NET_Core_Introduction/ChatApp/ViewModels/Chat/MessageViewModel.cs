namespace ChatApp.ViewModels.Chat;

using System.ComponentModel.DataAnnotations;

public class MessageViewModel
{
    [Required(ErrorMessage = "Sender cannot be empty.")]
    public string Sender { get; set; } = null!;

    [Required(ErrorMessage = "Message cannot be empty.")]
    [MaxLength(255, ErrorMessage = "Message cannot be over 255 symbols.")]
    public string Content { get; set; } = null!;
}
