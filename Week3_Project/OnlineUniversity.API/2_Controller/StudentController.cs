
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }


    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(_studentService.GetAllStudents());
    }

    [HttpGet("id/{id}")]
    public IActionResult GetStudentById(int id)
    {
        return Ok(_studentService.GetStudentById(id));
    }

    [HttpGet("name/{name}")]
    public IActionResult GetStudentByName(string name)
    {
        return Ok(_studentService.GetStudentByName(name));
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(Student student)
    {
        var new_student = _studentService.AddStudent(student);
        return Ok(await new_student);
    }

    [HttpDelete]
    public void RemoveStudent(int id)
    {
        // var deleteStudent = _studentService.DeleteStudentById(id);
        _studentService.DeleteStudentById(id);

        // if (deleteStudent is null)
        // {
        //     return NotFound();
        // }

        // return Ok(deleteStudent);
    }
}