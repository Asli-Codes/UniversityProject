using BLL.LogicServices;
using BOL.CommonEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CostumerPortalNew.Controllers
{
   
    
        [Route("api/[controller]")]
        [ApiController]
       public class StudentsController : ControllerBase
        {
            private readonly IStudentsLogic _studentsLogic;
            public StudentsController(IStudentsLogic studentsLogic)
            {
                _studentsLogic = studentsLogic;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<StudentsDTO>>> GetStudents()
            {
                var students = await _studentsLogic.GetStudentsAsync();
                return Ok(students);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<StudentsDTO>> GetStudent(int id)
            {
                var student = await _studentsLogic.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }

            [HttpPost]
            public async Task<ActionResult<StudentsDTO>> PostStudent(StudentsDTO studentDto)
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await _studentsLogic.AddStudentAsync(studentDto);
                return CreatedAtAction(nameof(GetStudent), new { id = studentDto.StudentId }, studentDto);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutStudent(int id, StudentsDTO studentDto)
            {
                if (id != studentDto.StudentId)
                {
                    return BadRequest("Öğrenci ID'leri uyuşmuyor.");
                }
               
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existingStudent = await _studentsLogic.GetStudentByIdAsync(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }


                await _studentsLogic.UpdateStudentAsync(studentDto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStudent(int id)
            {
                var student = await _studentsLogic.GetStudentByIdAsync(id);
                if (student == null)
                {
                    return NotFound();
                }
                await _studentsLogic.DeleteStudentAsync(id);
                return NoContent();
            }
        
    }
}
