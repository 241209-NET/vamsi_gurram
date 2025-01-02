
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineUniversity.API.Model;
using OnlineUniversity.API.Service;

namespace OnlineUniversity.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _CourseService;

    public CourseController(ICourseService CourseService)
    {
        _CourseService = CourseService;
    }


    [HttpGet]
    public IActionResult GetCourses()
    {
        return Ok(_CourseService.GetAllCourses());
    }

    [HttpGet("id/{id}")]
    public IActionResult GetCourseById(int id)
    {
        return Ok(_CourseService.GetCourseById(id));
    }

    [HttpGet("name/{name}")]
    public IActionResult GetCourseByName(string name)
    {
        return Ok(_CourseService.GetCourseByName(name));
    }

    [HttpPost]
    public async Task<IActionResult> AddCourse(Course Course)
    {
        var new_Course = _CourseService.AddCourse(Course);
        return Ok(await new_Course);
    }

    [HttpDelete]
    public void RemoveCourse(int id)
    {
        // var deleteCourse = _CourseService.DeleteCourseById(id);
        _CourseService.DeleteCourseById(id);

        // if (deleteCourse is null)
        // {
        //     return NotFound();
        // }

        // return Ok(deleteCourse);
    }
}