using Microsoft.AspNetCore.Identity;

namespace Education.EntityLayer.Concrete
{
    public class ApplicationUser:IdentityUser
    {
        public int ApplicationUserID { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int DepartmentID { get; set; }
    }
}
