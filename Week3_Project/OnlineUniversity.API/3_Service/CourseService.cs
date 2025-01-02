

using OnlineUniversity.API.Model;
using OnlineUniversity.API.Repository;

namespace OnlineUniversity.API.Service;

public class CourseService : ICourseService
{

    private readonly ICourseRepository _CourseRepository;

    public CourseService(ICourseRepository CourseRepository)
    {
        _CourseRepository = CourseRepository;
    }
    public Task<Course> AddCourse(Course newCourse)
    {

        return _CourseRepository.AddCourse(newCourse);

    }
    public IEnumerable<Course> GetAllCourses()
    {
        return _CourseRepository.GetAllCourses();
    }
    public Course? GetCourseById(int id)
    {
        return _CourseRepository.GetCourseById(id);
    }
    public IEnumerable<Course> GetCourseByName(string name)
    {
        return _CourseRepository.GetCourseByName(name);
    }
    public void DeleteCourseById(int id)
    {
        _CourseRepository.DeleteCourseById(id);
    }
}