namespace MVCWithEfCore.Models
{
    public class StudentSubject
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
