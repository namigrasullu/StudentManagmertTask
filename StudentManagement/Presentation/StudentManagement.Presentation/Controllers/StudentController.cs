using Microsoft.AspNetCore.Mvc;
using StudentManagement.Application.Dtos;
using StudentManagement.Application.Services;

namespace StudentManagement.Presentation.Controllers
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _studentService.GetAllAsync();
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _studentService.GetAsync(id);
                return Ok(result);
            }
            catch 
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _studentService.RemoveAsync(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(AddStudentDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _studentService.AddAsync(dto);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdateStudentDto dto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var result = await _studentService.UpdateAsync(dto);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
