namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Album
{
    public Album()
    {
        Songs = new HashSet<Song>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.AlbumNameType)]
    public string Name { get; set; } = null!;
    public DateTime ReleaseDate { get; set; }

    [ForeignKey(nameof(Producer))]
    public int? ProducerId { get; set; }
    public Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = null!;
    public decimal Price => Songs.Sum(s => s.Price);
}
