

using OnlineUniversity.API.Model;
using OnlineUniversity.API.Repository;

namespace OnlineUniversity.API.Service;

public class StudentService : IStudentService
{

    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public Task<Student> AddStudent(Student newStudent)
    {

        return _studentRepository.AddStudent(newStudent);

    }
    public IEnumerable<Student> GetAllStudents()
    {
        return _studentRepository.GetAllStudents();
    }
    public Student? GetStudentById(int id)
    {
        return _studentRepository.GetStudentById(id);
    }
    public IEnumerable<Student> GetStudentByName(string name)
    {
        return _studentRepository.GetStudentByName(name);
    }
    public void DeleteStudentById(int id)
    {
        _studentRepository.DeleteStudentById(id);
    }
}