using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        readonly IAnnouncementDal _announcementDal;

        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void TDelete(Announcement entity)
        {
            _announcementDal.Delete(entity);
        }

        public Announcement TGetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Announcement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public void TInsert(Announcement entity)
        {
            _announcementDal.Insert(entity);   
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}
