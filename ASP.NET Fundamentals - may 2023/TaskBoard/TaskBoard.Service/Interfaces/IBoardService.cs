using TaskBoard.Web.ViewModels.Board;

namespace TaskBoard.Service.Interfaces;

public interface IBoardService
{
    Task<IEnumerable<BoardDisplayViewModel>> AllBoardsAsync();

    Task<IEnumerable<BoardDropdownSelectViewModel>> AllBoardsDropdownSelectAsync();

    Task<bool> ExistsByIdAsync(int boardId);
}
