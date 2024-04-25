using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentCode { get; set; }
        public string? Description { get; set; }
        public ApplicationUser? User { get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
    }
}
