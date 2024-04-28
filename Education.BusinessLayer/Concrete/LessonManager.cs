using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class LessonManager:ILessonService
    {
        readonly ILessonDal _lessonDal;

        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void TDelete(Lesson entity)
        {
            _lessonDal.Delete(entity);
        }

        public Lesson TGetById(int id)
        {
            return _lessonDal.GetById(id);
        }

        public List<Lesson> TGetList()
        {
            return _lessonDal.GetList();
        }

        public void TInsert(Lesson entity)
        {
            _lessonDal.Insert(entity);
        }

        public void TUpdate(Lesson entity)
        {
            _lessonDal.Update(entity);
        }
    }
}
