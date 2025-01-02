using System.ComponentModel.DataAnnotations;

namespace OnlineUniversity.API.Model;

public class Student
{

    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Age { get; set; }
    public string? Address { get; set; }

    public List<Course> Courses { get; set; } = [];
}