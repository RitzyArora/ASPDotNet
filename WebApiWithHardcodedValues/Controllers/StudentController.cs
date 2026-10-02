using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWithHardcodedValues.Models;

namespace WebApiWithHardcodedValues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Student> students = new List<Student> {
            new Student{StudentID=1,StudentName="Alice",StudentAge=16,StudentMarks=86},
            new Student{StudentID=2,StudentName="Bob",StudentAge=18,StudentMarks=78},
            new Student{StudentID=3,StudentName="Jazz",StudentAge=17,StudentMarks=66},
            };

        [HttpGet("{studentID}")]
        public ActionResult<Student>GetStudentById(int studentID) 
        {
            var student=students.FirstOrDefault(value=>value.StudentID==studentID);
            if(student==null)
            { return NotFound(); }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            student.StudentID = students.Max(value => value.StudentID) + 1;
            students.Add(student);
            return CreatedAtAction(nameof(GetStudentById), new { studentID = student.StudentID }, student);
        //return Ok(student);
        }


        [HttpDelete("{studentID}")]
        public ActionResult<Student> DeleteStudentById(int studentID)
        {
            var student = students.FirstOrDefault(value => value.StudentID == studentID);
            if (student == null)
            { return NotFound(); }
            students.Remove(student);
            return NoContent();
        }
    }
}
//try getAll method