using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Absence
    {
        [Key]
        public int AbsenceID { get; set; }
        public int ApplicationUserID { get; set; }
        public int LessonID { get; set; }
        public int DepartmentID { get; set; }   
        public DateTime Date { get; set; }
        public ApplicationUser? User { get; set; }
        public Lesson? Lesson { get; set; }
        //var absence = dbContext.Absences
        //.Include(a => a.ApplicationUser)
        //.FirstOrDefault();
    }
}
