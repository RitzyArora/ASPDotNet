using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {
            var students = new List<Student> { 
            new Student{StudentID=1,StudentName="Alice",StudentAge=16,StudentMarks=86},
            new Student{StudentID=2,StudentName="Bob",StudentAge=18,StudentMarks=78},
            new Student{StudentID=3,StudentName="Jazz",StudentAge=17,StudentMarks=66},
            };

            ViewData["Message"] = "Hello learning the usage of ViewData";
            ViewBag.Greeting = "Hello welcome to the world of MVC apps";
            return View(students);
        }
    }
}
