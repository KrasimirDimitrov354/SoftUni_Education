namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;
using Enums;

public class Song
{
    public Song()
    {
        SongPerformers = new HashSet<SongPerformer>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.SongNameType)]
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public Genre Genre { get; set; }
    public TimeSpan Duration { get; set; }

    [Column(TypeName = FieldType.SongCreatedOnType)]
    public DateTime CreatedOn { get; set; }

    [ForeignKey(nameof(Album))]
    public int? AlbumId { get; set; }
    public Album? Album { get; set; }

    [ForeignKey(nameof(Writer))]
    public int WriterId { get; set; }
    public Writer Writer { get; set; } = null!;  

    public virtual ICollection<SongPerformer> SongPerformers { get; set; } = null!;
}
