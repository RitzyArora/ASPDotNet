using EFCoreDatabaseFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDatabaseFirstContext _appDbContext;
        public StudentController(StudentDatabaseFirstContext appDbContext)
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
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _appDbContext.Students.Add(student);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction("GetStudentById", new { id = student.Studentid }, student);
        }


        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudentById(int id, Student student)
        {
            if (id != student.Studentid)
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
                if (!_appDbContext.Students.Any(x => x.Studentid == id))
                    return NotFound();
                throw;
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
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
