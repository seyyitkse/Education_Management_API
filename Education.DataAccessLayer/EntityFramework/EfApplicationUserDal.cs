using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfApplicationUserDal : GenericRepository<ApplicationUser>, IApplicationUserDal
    {
        public EfApplicationUserDal(AppDbContext context) : base(context)
        {
        }
    }
}
