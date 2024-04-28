using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfLessonDal:GenericRepository<Lesson>,ILessonDal
    {
        public EfLessonDal(AppDbContext context) : base(context)
        {
        }
    }
}
