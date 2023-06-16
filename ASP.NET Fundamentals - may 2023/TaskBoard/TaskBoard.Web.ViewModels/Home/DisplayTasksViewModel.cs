namespace TaskBoard.Web.ViewModels.Home;

public class DisplayTasksViewModel
{
    public string Username { get; set; } = null!;

    public int TasksCountTotal { get; set; }

    public int TasksCountUser { get; set; }

    public ICollection<UserTasksViewModel> UserTasks { get; set; } = new HashSet<UserTasksViewModel>();
}
