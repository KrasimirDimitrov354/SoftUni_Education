namespace TaskBoard.Service;

using Microsoft.EntityFrameworkCore;

using Data;
using Interfaces;
using Data.Models;
using Web.ViewModels.Home;

public class HomeService : IHomeService
{
    private readonly TaskBoardDbContext dbContext;

    public HomeService(TaskBoardDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<DisplayTasksViewModel> DisplayAllTasksAsync(string userId, string username)
    {
        Task[] allTasksForUser = await dbContext.Tasks
            .Where(t => t.OwnerId == userId)
            .ToArrayAsync();

        DisplayTasksViewModel tasksToDisplay =  new DisplayTasksViewModel
            {
                Username = username,
                TasksCountTotal = dbContext.Tasks.Count(),
                TasksCountUser = allTasksForUser.Count()
            };

        Board[] boards = await dbContext.Boards.ToArrayAsync();

        foreach (Board board in boards)
        {
            UserTasksViewModel boardTasks = new UserTasksViewModel()
            {
                BoardName = board.Name
            };

            bool tasksInBoard = allTasksForUser.Any(t => t.Board.Id == board.Id);

            if (tasksInBoard)
            {
                int tasksCount = allTasksForUser.Where(t => t.Board.Id == board.Id).Count();
                boardTasks.BoardTasksCount = tasksCount;
            }
            else
            {
                boardTasks.BoardTasksCount = 0;
            }

            tasksToDisplay.UserTasks.Add(boardTasks);
        }

        return tasksToDisplay;
    }
}
