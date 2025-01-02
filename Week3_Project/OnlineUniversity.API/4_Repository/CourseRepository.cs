using Microsoft.EntityFrameworkCore;
using OnlineUniversity.API.Data;
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Repository;

public class CourseRepository : ICourseRepository
{
    //Need the DB Object to work with.
    private readonly StudentContext _StudentContext;

    public CourseRepository(StudentContext StudentContext) => _StudentContext = StudentContext;

    public IEnumerable<Course> GetAllCourses()
    {
        return _StudentContext.Courses
                .Include(c => c.Students)
                .Include(c => c.Teachers)
                .ToList();
    }

    public async Task<Course> AddCourse(Course newCourse)
    {
        //Insert into Courses Values (newCourse)
        await _StudentContext.Courses.AddAsync(newCourse);
        await _StudentContext.SaveChangesAsync();
        return newCourse;
    }

    public Course? GetCourseById(int id)
    {
        return _StudentContext.Courses.Find(id);
    }

    public void DeleteCourseById(int id)
    {
        var Course = GetCourseById(id);
        _StudentContext.Courses.Remove(Course!);
        _StudentContext.SaveChanges();
    }

    public IEnumerable<Course> GetCourseByName(string name)
    {
        var CourseList = _StudentContext.Courses.Where(p => p.Name.Contains(name)).ToList();
        return CourseList;
    }
}