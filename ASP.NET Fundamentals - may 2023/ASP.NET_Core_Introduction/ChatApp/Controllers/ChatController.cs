namespace ChatApp.Controllers;

using Microsoft.AspNetCore.Mvc;

using ViewModels.Chat;

public class ChatController : Controller
{
    private static readonly ICollection<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();

    [HttpGet]
    public IActionResult Initialize(ChatViewModel chatViewModel)
    {
        chatViewModel = new ChatViewModel()
        {
            AllMessages = messages.Select(m => new MessageViewModel()
            {
                Sender = m.Key,
                Content = m.Value
            })
            .ToArray()
        };

        return View(chatViewModel);
    }

    [HttpPost]
    public IActionResult Send(ChatViewModel chatViewModel)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Initialize", chatViewModel);
        }

        var currentMessage = new KeyValuePair<string, string>(chatViewModel.CurrentMessage.Sender, chatViewModel.CurrentMessage.Content);
        messages.Add(currentMessage);

        return this.RedirectToAction("Initialize");
    }

    [HttpPost]
    public IActionResult RemoveLastMessage(string senderName)
    {
        var messagesAsStack = new Stack<KeyValuePair<string, string>>(messages);
        var lastMessageBySender = messagesAsStack
            .Where(m => m.Key.ToLower() == senderName.ToLower())
            .FirstOrDefault();

        if (lastMessageBySender.Equals(null))
        {
            return this.RedirectToAction("Initialize");
        }

        messages.Remove(lastMessageBySender);
        return this.RedirectToAction("Initialize");
    }
}
