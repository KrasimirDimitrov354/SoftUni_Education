namespace ChatApp.ViewModels.Chat;

public class ChatViewModel
{
    public ChatViewModel()
    {
        AllMessages = new List<MessageViewModel>();
    }
    
    public MessageViewModel CurrentMessage { get; set; } = null!;

    public ICollection<MessageViewModel> AllMessages { get; set; }
}
