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