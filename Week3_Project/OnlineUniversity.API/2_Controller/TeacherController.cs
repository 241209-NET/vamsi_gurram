
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _TeacherService;

    public TeacherController(ITeacherService TeacherService)
    {
        _TeacherService = TeacherService;
    }


    [HttpGet]
    public IActionResult GetTeachers()
    {
        return Ok(_TeacherService.GetAllTeachers());
    }

    [HttpGet("id/{id}")]
    public IActionResult GetTeacherById(int id)
    {
        return Ok(_TeacherService.GetTeacherById(id));
    }

    [HttpGet("name/{name}")]
    public IActionResult GetTeacherByName(string name)
    {
        return Ok(_TeacherService.GetTeacherByName(name));
    }

    [HttpPost]
    public async Task<IActionResult> AddTeacher(Teacher Teacher)
    {
        var new_Teacher = _TeacherService.AddTeacher(Teacher);
        return Ok(await new_Teacher);
    }

    [HttpDelete]
    public void RemoveTeacher(int id)
    {
        // var deleteTeacher = _TeacherService.DeleteTeacherById(id);
        _TeacherService.DeleteTeacherById(id);

        // if (deleteTeacher is null)
        // {
        //     return NotFound();
        // }

        // return Ok(deleteTeacher);
    }
}