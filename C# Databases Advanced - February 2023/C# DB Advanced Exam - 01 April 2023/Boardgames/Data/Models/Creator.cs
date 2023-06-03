namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [MaxLength(FieldValidation.CreatorNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [MaxLength(FieldValidation.CreatorNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Boardgame> Boardgames { get; set; } = null!;
}
