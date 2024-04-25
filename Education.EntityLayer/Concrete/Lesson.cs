using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Lesson
    {
        [Key]
        public int LessonID { get; set; }
        public string? LessonCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TeacherID { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public Lesson()
        {
            Status = 1;
        }
        public ICollection<Absence>? Absences { get; set; }
    }
}
