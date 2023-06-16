namespace TaskBoard.Data.Models;

using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

using static Common.EntityFieldValidation.Board;
using static Common.EntityColumnComments.Board;

public class Board
{
    public Board()
    {
        Tasks = new HashSet<Task>();
    }

    [Key]
    [Comment(IdComment)]
    public int Id { get; set; }

    [Required]
    [MaxLength(NameMaxLength)]
    [Comment(NameComment)]
    public string Name { get; set; } = null!;

    public ICollection<Task> Tasks { get; set; }
}
