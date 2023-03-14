namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Course
{
    public Course()
    {
        Students = new HashSet<Student>();
        Resources = new HashSet<Resource>();
        Homeworks = new HashSet<Homework>();
        StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int CourseId { get; set; }

    [Column(TypeName = FieldType.CourseNameType)]
    public string Name { get; set; } = null!;

    [Column(TypeName = FieldType.CourseDescriptionType)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Student> Students { get; set; } = null!;
    public virtual ICollection<Resource> Resources { get; set; } = null!;
    public virtual ICollection<Homework> Homeworks { get; set; } = null!;
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = null!;
}
