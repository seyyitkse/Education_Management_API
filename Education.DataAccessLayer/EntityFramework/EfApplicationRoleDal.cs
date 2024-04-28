using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfApplicationRoleDal : GenericRepository<ApplicationRole>, IApplicationRoleDal
    {
        public EfApplicationRoleDal(AppDbContext context) : base(context)
        {
        }
    }
}
