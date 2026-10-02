namespace WebApplication1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation Property
        public ICollection<Student> Students { get; set; }
    }

}
