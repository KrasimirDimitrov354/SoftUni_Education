namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Writer
{
    public Writer()
    {
        Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.WriterNameType)]
    public string Name { get; set; } = null!;

    [Column(TypeName = FieldType.WriterPseudonymType)]
    public string? Pseudonym { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = null!;
}
