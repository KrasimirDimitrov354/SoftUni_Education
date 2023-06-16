namespace TaskBoard.Service.Interfaces;

using Web.ViewModels.Home;

public interface IHomeService
{
    Task<DisplayTasksViewModel> DisplayAllTasksAsync(string userId, string username);
}
