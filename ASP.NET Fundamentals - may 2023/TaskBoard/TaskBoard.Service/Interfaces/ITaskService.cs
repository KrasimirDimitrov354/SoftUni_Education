namespace TaskBoard.Service.Interfaces;

using Web.ViewModels.Task;

public interface ITaskService
{
    Task AddAsync(string ownerId, TaskFormViewModel taskToAdd);

    Task<string> FindIdOfLatestTaskAsync(string ownerId);
    
    Task<TaskDetailsViewModel> DisplayTaskDetailsAsync(string taskId);

    Task<TaskFormViewModel> GetForModificationAsync(string taskId, string userId);

    Task EditAsync(string taskId, string userId, TaskFormViewModel viewModel);

    Task DeleteAsync(string taskId, string userId, TaskFormViewModel viewModel);
}
