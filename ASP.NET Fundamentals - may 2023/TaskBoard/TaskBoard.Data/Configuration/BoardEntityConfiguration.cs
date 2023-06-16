namespace TaskBoard.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Seeder;
using Data.Models;

public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
{
    private readonly BoardSeeder boardSeeder;

    public BoardEntityConfiguration()
    {
        boardSeeder = new BoardSeeder();
    }

    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasData(boardSeeder.GenerateBoards());
    }
}
