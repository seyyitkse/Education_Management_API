using Education.EntityLayer.Concrete;

namespace Education.DtoLayer.Dtos.AbsenceDto
{
    public class CreateAbsenceDto
    {
        public int DepartmentID { get; set; }
        public DateTime Date { get; set; }
        public int ApplicationUserID { get; set; }
        public ApplicationUser? User { get; set; }
        public int LessonID { get; set; }
        public Lesson? Lesson { get; set; }
    }
}
