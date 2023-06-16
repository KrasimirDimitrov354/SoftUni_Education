namespace TaskBoard.Data.Seeder;

using Data.Models;

internal class BoardSeeder
{
    internal Board[] GenerateBoards()
    {
        ICollection<Board> boards = new HashSet<Board>();

        Board board;

        board = new Board()
        {
            Id = 1,
            Name = "Open"
        };
        boards.Add(board);

        board = new Board()
        {
            Id = 2,
            Name = "In Progress"
        };
        boards.Add(board);

        board = new Board()
        {
            Id = 3,
            Name = "Done"
        };
        boards.Add(board);

        return boards.ToArray();
    }
}
