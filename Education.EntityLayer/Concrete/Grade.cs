using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int LessonId { get; set; }

        [Required]
        [Range(0, 100)]
        public int Score { get; set; }
    }
}
