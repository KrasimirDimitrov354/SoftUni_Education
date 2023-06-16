namespace TaskBoard.App.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Service.Interfaces;
using Web.ViewModels.Board;

[Authorize]
public class BoardController : Controller
{
    private readonly IBoardService boardService;

    public BoardController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<BoardDisplayViewModel> allBoards = await boardService.AllBoardsAsync();

        return View(allBoards);
    }
}
