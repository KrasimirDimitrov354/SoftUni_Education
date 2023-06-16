namespace TaskBoard.Service;

using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Data;
using Interfaces;
using Web.ViewModels.Board;
using Web.ViewModels.Task;

public class BoardService : IBoardService
{
    private readonly TaskBoardDbContext dbContext;

    public BoardService(TaskBoardDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<BoardDisplayViewModel>> AllBoardsAsync()
    {
        IEnumerable<BoardDisplayViewModel> allBoards = await dbContext.Boards
            .Select(b => new BoardDisplayViewModel
            {
                Name = b.Name,
                Tasks = b.Tasks
                    .Select(t => new TaskBoardViewModel
                    {
                        Id = t.Id.ToString(),
                        Title = t.Title,
                        Description = t.Description,
                        Owner = t.Owner.UserName
                    })
                    .ToArray()
            })
        .ToArrayAsync();

        return allBoards;
    }

    public async Task<IEnumerable<BoardDropdownSelectViewModel>> AllBoardsDropdownSelectAsync()
    {
        IEnumerable<BoardDropdownSelectViewModel> allBoardsDropdownSelect = await dbContext.Boards
            .Select(b => new BoardDropdownSelectViewModel
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToArrayAsync();

        return allBoardsDropdownSelect;
    }

    public async Task<bool> ExistsByIdAsync(int boardId)
    {
        return await dbContext.Boards.AnyAsync(b => b.Id == boardId);
    }
}