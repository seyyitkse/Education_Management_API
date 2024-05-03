using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfGradeDal : GenericRepository<Grade>,IGradeDal
    {
        public EfGradeDal(AppDbContext context) : base(context)
        {
        }
    }
}
