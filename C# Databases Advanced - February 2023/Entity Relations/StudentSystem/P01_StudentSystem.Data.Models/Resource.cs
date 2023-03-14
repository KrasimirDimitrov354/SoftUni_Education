namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;
using Enums;

public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Column(TypeName = FieldType.ResourceNameType)]
    public string Name { get; set; } = null!;

    [Column(TypeName = FieldType.ResourceUrlType)]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set;} = null!;
}
