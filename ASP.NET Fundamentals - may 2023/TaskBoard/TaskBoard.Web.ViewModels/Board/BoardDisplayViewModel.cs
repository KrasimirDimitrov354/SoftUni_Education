namespace TaskBoard.Web.ViewModels.Board;

using Task;

public class BoardDisplayViewModel
{
    public string Name { get; set; } = null!;

    public IEnumerable<TaskBoardViewModel> Tasks { get; set; } = null!;
}
