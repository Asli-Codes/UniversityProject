
using BLL.LogicServices;
using BOL.CommonEntities;
using Microsoft.AspNetCore.Mvc;

namespace CostumerPortalNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController :ControllerBase
    {
        private readonly ICoursesLogic _coursesLogic;

        public CoursesController(ICoursesLogic coursesLogic)
        {
            _coursesLogic = coursesLogic;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            var courses = await _coursesLogic.GetCoursesAsync();
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDTO>> GetCourse(int id)
        {
            var course = await _coursesLogic.GetCourseByIdAsync(id);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult<CourseDTO>> PostCourse(CourseDTO courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _coursesLogic.AddCourseAsync(courseDto);
            return CreatedAtAction(nameof(GetCourse), new { id = courseDto.CourseId }, courseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDTO courseDto)
        {
            if (id != courseDto.CourseId)
            {
                return BadRequest("Kurs ID'leri uyuşmuyor.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          var existingCourse = await _coursesLogic.GetCourseByIdAsync(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            await _coursesLogic.UpdateCourseAsync(courseDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        { 
            var course = await _coursesLogic.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            await _coursesLogic.DeleteCourseAsync(id);
            return NoContent();
        }
    }
}
