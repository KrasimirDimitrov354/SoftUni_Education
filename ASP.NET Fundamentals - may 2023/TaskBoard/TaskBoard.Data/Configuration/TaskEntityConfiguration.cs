namespace TaskBoard.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Seeder;
using Data.Models;

public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
{
    private readonly TaskSeeder taskSeeder;

    public TaskEntityConfiguration()
    {
        taskSeeder = new TaskSeeder();
    }

    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(taskSeeder.GenerateTasks());
    }
}
