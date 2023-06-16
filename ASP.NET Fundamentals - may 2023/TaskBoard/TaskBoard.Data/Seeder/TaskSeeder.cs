namespace TaskBoard.Data.Seeder;

using Data.Models;

internal class TaskSeeder
{
    internal Task[] GenerateTasks()
    {
        ICollection<Task> tasks = new HashSet<Task>();
        Task task;

        task = new Task()
        {
            Title = "Improve CSS styles",
            Description = "Implement better styling for all public pages",
            CreatedOn = DateTime.UtcNow.AddDays(-10),
            OwnerId = "0430e6cf-b8d7-4a77-8d32-fccd1ea74279",
            BoardId = 1
        };
        tasks.Add(task);

        task = new Task()
        {
            Title = "Android Client App",
            Description = "Create Android client App for the RESTful TaskBoard service",
            CreatedOn = DateTime.UtcNow.AddDays(-5),
            OwnerId = "2a7f468e-0771-4fab-b387-d9722d98daa3",
            BoardId = 1
        };
        tasks.Add(task);

        task = new Task()
        {
            Title = "Desktop Client App",
            Description = "Create Desktop client App for the RESTful TaskBoard service",
            CreatedOn = DateTime.UtcNow.AddDays(-100),
            OwnerId = "3f39c124-5996-4125-a43a-68976db12d50",
            BoardId = 2
        };
        tasks.Add(task);

        task = new Task()
        {
            Title = "Create Tasks",
            Description = "Implement [Create Task] page for adding tasks",
            CreatedOn = DateTime.UtcNow.AddDays(-100),
            OwnerId = "3f39c124-5996-4125-a43a-68976db12d50",
            BoardId = 3
        };
        tasks.Add(task);

        return tasks.ToArray();
    }
}
