using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class CafeteriaCardManager : ICafeteriaCardService
    {
        readonly ICafeteriaCardDal _cafeteriaCardDal;

        public CafeteriaCardManager(ICafeteriaCardDal cafeteriaCardDal)
        {
            _cafeteriaCardDal = cafeteriaCardDal;
        }

        public void TDelete(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Delete(entity);
        }

        public CafeteriaCard TGetById(int id)
        {
            return _cafeteriaCardDal.GetById(id);
        }

        public List<CafeteriaCard> TGetList()
        {
            return _cafeteriaCardDal.GetList();
        }

        public void TInsert(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Insert(entity);
        }

        public void TUpdate(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Update(entity);
        }
    }
}