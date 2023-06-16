namespace TaskBoard.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using TaskBoard.Data.Models;
using TaskBoard.Data.Configuration;

public class TaskBoardDbContext : IdentityDbContext
{
    public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
        : base(options)
    {

    }

    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<Board> Boards { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BoardEntityConfiguration());
        builder.ApplyConfiguration(new TaskEntityConfiguration());

        base.OnModelCreating(builder);
    }
}