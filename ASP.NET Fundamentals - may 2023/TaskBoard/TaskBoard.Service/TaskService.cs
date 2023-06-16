namespace TaskBoard.Service;

using Microsoft.EntityFrameworkCore;

using Data;
using Interfaces;
using Web.ViewModels.Task;

public class TaskService : ITaskService
{
    private readonly TaskBoardDbContext dbContext;

    public TaskService(TaskBoardDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string ownerId, TaskFormViewModel viewModel)
    {
        Data.Models.Task task = new Data.Models.Task()
        {
            Title = viewModel.Title,
            Description = viewModel.Description,
            CreatedOn = DateTime.UtcNow,
            EditedOn = DateTime.MinValue,
            BoardId = viewModel.BoardId,
            OwnerId = ownerId
        };

        await dbContext.Tasks.AddAsync(task);
        await dbContext.SaveChangesAsync();
    }

    public async Task<string> FindIdOfLatestTaskAsync(string ownerId)
    {
        var latestTaskOfUser = await dbContext.Tasks
            .Where(t => t.OwnerId == ownerId)
            .OrderByDescending(t => t.CreatedOn)
            .FirstAsync();

        return latestTaskOfUser.Id.ToString();
    }

    public async Task<TaskDetailsViewModel> DisplayTaskDetailsAsync(string taskId)
    {
        TaskDetailsViewModel taskDetails = await dbContext.Tasks
            .Where(t => t.Id.ToString() == taskId)
            .Select(t => new TaskDetailsViewModel
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                Owner = t.Owner.UserName,
                CreatedOn = t.CreatedOn.ToString("F"),
                EditedOn = t.EditedOn != DateTime.MinValue ? t.EditedOn.ToString("F") : string.Empty,
                Board = t.Board.Name
            })
            .FirstAsync();

        return taskDetails;
    }

    public async Task<TaskFormViewModel> GetForModificationAsync(string taskId, string userId)
    {
        TaskFormViewModel taskToEdit = await dbContext.Tasks
            .Where(t => t.OwnerId == userId && t.Id.ToString() == taskId)
            .Select(t => new TaskFormViewModel
            {
                Title = t.Title,
                Description = t.Description,
                BoardId = t.BoardId
            })
            .FirstAsync();

        return taskToEdit;
    }

    public async Task EditAsync(string taskId, string userId, TaskFormViewModel viewModel)
    {
        Data.Models.Task taskToEdit = await dbContext.Tasks
            .FirstAsync(t => t.OwnerId == userId && t.Id.ToString() == taskId);

        taskToEdit.Title = viewModel.Title;
        taskToEdit.Description = viewModel.Description;
        taskToEdit.BoardId = viewModel.BoardId;
        taskToEdit.EditedOn = DateTime.UtcNow;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(string taskId, string userId, TaskFormViewModel viewModel)
    {
        Data.Models.Task taskToDelete = await dbContext.Tasks
            .FirstAsync(t => t.OwnerId == userId && t.Id.ToString() == taskId);

        dbContext.Tasks.Remove(taskToDelete);
        await dbContext.SaveChangesAsync();
    }
}
