namespace MVCWithEfCore.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }

        // Navigation property for many-to-many
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}