namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Position
{
    public Position()
    {
        Players = new HashSet<Player>();
    }

    [Key]
    public int PositionId { get; set; }

    [MaxLength(PropertyLengthValidation.PositionNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Player> Players { get; set; } = null!;
}
