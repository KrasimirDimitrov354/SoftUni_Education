namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Student
{
    public Student()
    {
        Courses = new HashSet<Course>();
        Homeworks = new HashSet<Homework>();
        StudentsCourses = new HashSet<StudentCourse>();
    }

    [Key]
    public int StudentId { get; set; }

    [Column(TypeName = FieldType.StudentNameType)]
    public string Name { get; set; } = null!;

    [Column(TypeName = FieldType.StudentPhoneNumberType)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    [Column(TypeName = FieldType.StudentBirthdayType)]
    public DateTime? Birthday { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = null!;
    public virtual ICollection<Homework> Homeworks { get; set; } = null!;
    public virtual ICollection<StudentCourse> StudentsCourses { get; set; } = null!;
}