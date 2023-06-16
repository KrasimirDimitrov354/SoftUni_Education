namespace TaskBoard.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using static Common.EntityFieldValidation.Task;
using static Common.EntityColumnComments.Task;

public class Task
{
    public Task()
    {
        Id = Guid.NewGuid();
    }

    [Key]
    [Comment(IdComment)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    [Comment(TitleComment)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    [Comment(DescriptionComment)]
    public string Description { get; set; } = null!;

    [Comment(CreatedOnComment)]
    public DateTime CreatedOn { get; set; }

    [Comment(EditedOnComment)]
    public DateTime EditedOn { get; set; }

    [Required]
    [Comment(BoardIdComment)]
    public int BoardId { get; set; }
    public Board Board { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Owner))]
    [Comment(OwnerIdComment)]
    public string OwnerId { get; set; } = null!;
    public IdentityUser Owner { get; set; } = null!;
}