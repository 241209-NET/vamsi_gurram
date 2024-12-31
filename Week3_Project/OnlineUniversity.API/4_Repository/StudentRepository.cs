using Microsoft.EntityFrameworkCore;
using OnlineUniversity.API.Data;
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Repository;

public class StudentRepository : IStudentRepository
{
    //Need the DB Object to work with.
    private readonly StudentContext _StudentContext;

    public StudentRepository(StudentContext StudentContext) => _StudentContext = StudentContext;

    public IEnumerable<Student> GetAllStudents()
    {
        return _StudentContext.Students.ToList();
    }

    public async Task<Student> AddStudent(Student newStudent)
    {
        //Insert into Students Values (newStudent)
        await _StudentContext.Students.AddAsync(newStudent);
        await _StudentContext.SaveChangesAsync();
        return newStudent;
    }

    public Student? GetStudentById(int id)
    {
        return _StudentContext.Students.Find(id);
    }

    public void DeleteStudentById(int id)
    {
        var Student = GetStudentById(id);
        _StudentContext.Students.Remove(Student!);
        _StudentContext.SaveChanges();
    }

    public IEnumerable<Student> GetStudentByName(string name)
    {
        var StudentList = _StudentContext.Students.Where(p => p.Name.Contains(name)).ToList();
        return StudentList;
    }
}