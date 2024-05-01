using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfCafeteriaCardDal : GenericRepository<CafeteriaCard>, ICafeteriaCardDal
    {
        public EfCafeteriaCardDal(AppDbContext context) : base(context)
        {
        }
    }
}
