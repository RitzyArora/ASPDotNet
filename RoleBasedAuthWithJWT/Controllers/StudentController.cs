using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthWithJWT.Data;
using RoleBasedAuthWithJWT.Models;
namespace RoleBasedAuthWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public StudentController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            return await _appDbContext.Students.ToListAsync();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;

        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction("GetStudentById", new { id = student.StudentId }, student);
        }


        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Student>> UpdateStudentById(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }
            _appDbContext.Entry(student).State = EntityState.Modified;
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_appDbContext.Students.Any(x => x.StudentId == id))
                    return NotFound();
                throw;
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Student>> DeleteStudentById(int id)
        {
            var student = await _appDbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _appDbContext.Students.Remove(student);
            await _appDbContext.SaveChangesAsync();
            return NoContent();

        }
    }
}
