using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentID { get; set; }
        //public Department? Department { get; set; }
        //public ICollection<Absence>? Absences { get; set; }
        public int CafeteriaCardID { get; set; }
        //public ICollection<CafeteriaCard>? CafeteriaCards { get; set; }
    }
}
