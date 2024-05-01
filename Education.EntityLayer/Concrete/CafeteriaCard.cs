using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class CafeteriaCard
    {
        [Key]
        public int MealCardID { get; set; }
       
        public byte? CardNumber { get; set; }
        public int Balance { get; set; }
        public int ApplicationUserID { get; set; }
        //public ApplicationUser? User { get; set; }

    }
}
