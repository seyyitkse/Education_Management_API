using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        public EfAnnouncementDal(DbContext context) : base(context)
        {
        }
    }
}
