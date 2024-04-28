using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfDepartmentDal:GenericRepository<Department>, IDepartmentDal
    {
        public EfDepartmentDal(AppDbContext context) : base(context)
        {
        }
    }

}
