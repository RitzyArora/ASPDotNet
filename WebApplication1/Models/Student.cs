namespace WebApplication1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Property
        public Department Department { get; set; }
    }

}
