

using OnlineUniversity.API.Model;
using OnlineUniversity.API.Repository;

namespace OnlineUniversity.API.Service;

public class TeacherService : ITeacherService
{

    private readonly ITeacherRepository _TeacherRepository;

    public TeacherService(ITeacherRepository TeacherRepository)
    {
        _TeacherRepository = TeacherRepository;
    }
    public Task<Teacher> AddTeacher(Teacher newTeacher)
    {

        return _TeacherRepository.AddTeacher(newTeacher);

    }
    public IEnumerable<Teacher> GetAllTeachers()
    {
        return _TeacherRepository.GetAllTeachers();
    }
    public Teacher? GetTeacherById(int id)
    {
        return _TeacherRepository.GetTeacherById(id);
    }
    public IEnumerable<Teacher> GetTeacherByName(string name)
    {
        return _TeacherRepository.GetTeacherByName(name);
    }
    public void DeleteTeacherById(int id)
    {
        _TeacherRepository.DeleteTeacherById(id);
    }
}