
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Service;

public interface ICourseService
{
    Task<Course> AddCourse(Course newCourse);
    IEnumerable<Course> GetAllCourses();
    Course? GetCourseById(int id);
    IEnumerable<Course> GetCourseByName(string name);
    void DeleteCourseById(int id);
}