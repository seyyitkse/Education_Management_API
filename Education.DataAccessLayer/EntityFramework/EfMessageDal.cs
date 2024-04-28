using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>
    {
        public EfMessageDal(AppDbContext context) : base(context)
        {
        }
    }
}
