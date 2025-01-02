using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Repository;

public interface IStudentRepository
{
    //CRUD
    Task<Student> AddStudent(Student newStudent);
    IEnumerable<Student> GetAllStudents();
    Student? GetStudentById(int id);
    IEnumerable<Student> GetStudentByName(string name);
    void DeleteStudentById(int id);
}


public interface ICourseRepository
{
    //CRUD
    Task<Course> AddCourse(Course newCourse);
    IEnumerable<Course> GetAllCourses();
    Course? GetCourseById(int id);
    IEnumerable<Course> GetCourseByName(string name);
    void DeleteCourseById(int id);
}

public interface ITeacherRepository
{
    //CRUD
    Task<Teacher> AddTeacher(Teacher newTeacher);
    IEnumerable<Teacher> GetAllTeachers();
    Teacher? GetTeacherById(int id);
    IEnumerable<Teacher> GetTeacherByName(string name);
    void DeleteTeacherById(int id);
}