using AcademiK_API.Logic.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiK_API.Controllers
{
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
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return students.Any() ? Ok(students) : NotFound() as IActionResult;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentById(id);
                return Ok(student);

            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
