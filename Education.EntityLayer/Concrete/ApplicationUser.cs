using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser
    {
        [Key]
        public int ApplicationUserID { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentID { get; set; }
        public Department? Department { get; set; }
        public ICollection<Absence>? Absences { get; set; }
    }
}
