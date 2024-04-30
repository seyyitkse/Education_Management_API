using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfAbsenceDal : GenericRepository<Absence>, IAbsenceDal
    {
        public EfAbsenceDal(AppDbContext context) : base(context)
        {
        }

    }

}
