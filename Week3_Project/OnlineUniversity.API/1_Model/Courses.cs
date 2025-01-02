
namespace OnlineUniversity.API.Model;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<Student> Students { get; set; } = [];
    public List<Teacher> Teachers { get; set; } = [];

}