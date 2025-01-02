using Microsoft.EntityFrameworkCore;
using OnlineUniversity.API.Data;
using OnlineUniversity.API.Model;

namespace OnlineUniversity.API.Repository;

public class TeacherRepository : ITeacherRepository
{
    //Need the DB Object to work with.
    private readonly StudentContext _StudentContext;

    public TeacherRepository(StudentContext StudentContext) => _StudentContext = StudentContext;

    public IEnumerable<Teacher> GetAllTeachers()
    {
        return _StudentContext.Teachers.ToList();
    }

    public async Task<Teacher> AddTeacher(Teacher newTeacher)
    {
        //Insert into Teachers Values (newTeacher)
        await _StudentContext.Teachers.AddAsync(newTeacher);
        await _StudentContext.SaveChangesAsync();
        return newTeacher;
    }

    public Teacher? GetTeacherById(int id)
    {
        return _StudentContext.Teachers.Find(id);
    }

    public void DeleteTeacherById(int id)
    {
        var Teacher = GetTeacherById(id);
        _StudentContext.Teachers.Remove(Teacher!);
        _StudentContext.SaveChanges();
    }

    public IEnumerable<Teacher> GetTeacherByName(string name)
    {
        var TeacherList = _StudentContext.Teachers.Where(p => p.Name.Contains(name)).ToList();
        return TeacherList;
    }
}