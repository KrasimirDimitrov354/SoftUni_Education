namespace MusicHub.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Producer
{
    public Producer()
    {
        Albums = new HashSet<Album>();
    }

    [Key]
    public int Id { get; set; }

    [Column(TypeName = FieldType.ProducerNameType)]
    public string Name { get; set; } = null!;

    [Column(TypeName = FieldType.ProducerPseudonymType)]
    public string? Pseudonym { get; set; }

    [Column(TypeName = FieldType.ProducerPhoneNumberType)]
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = null!;
}
