namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Performer
{
    public Performer()
    {
        PerformerSongs = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.PerformerFirstNameType)]
    public string FirstName { get; set; } = null!;

    [Column(TypeName = FieldType.PerformerLastNameType)]
    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public decimal NetWorth { get; set; }

    public virtual ICollection<SongPerformer> PerformerSongs { get; set; } = null!;
}
