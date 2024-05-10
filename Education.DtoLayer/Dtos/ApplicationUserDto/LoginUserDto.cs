using System.ComponentModel.DataAnnotations;

namespace Education.DtoLayer.Dtos.ApplicationUserDto
{
    public class LoginUserDto
    {
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
