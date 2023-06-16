namespace TaskBoard.Web.ViewModels.Task;

public class TaskDetailsViewModel : TaskBoardViewModel
{
    public string CreatedOn { get; set; } = null!;

    public string EditedOn { get; set; } = null!;

    public string Board { get; set; } = null!;
}
