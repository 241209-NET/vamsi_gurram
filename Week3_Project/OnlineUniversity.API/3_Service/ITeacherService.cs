
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Service;

public interface ITeacherService
{
    Task<Teacher> AddTeacher(Teacher newTeacher);
    IEnumerable<Teacher> GetAllTeachers();
    Teacher? GetTeacherById(int id);
    IEnumerable<Teacher> GetTeacherByName(string name);
    void DeleteTeacherById(int id);
}