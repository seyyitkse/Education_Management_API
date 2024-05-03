using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class GradeManager : IGradeService
    {
        private readonly IGradeDal _gradeDal;

        public GradeManager(IGradeDal gradeDal)
        {
            _gradeDal = gradeDal;
        }

        public List<Grade> GetGradesByStudentId(int studentId)
        {
            return _gradeDal.GetGradesByStudentId(studentId);
        }

        public void TDelete(Grade entity)
        {
            _gradeDal.Delete(entity);
        }

        public Grade TGetById(int id)
        {
            return _gradeDal.GetById(id);
        }

        public List<Grade> TGetList()
        {
            return _gradeDal.GetList();
        }

        public void TInsert(Grade entity)
        {
            _gradeDal.Insert(entity);
        }

        public void TUpdate(Grade entity)
        {
            _gradeDal.Update(entity);
        }
    }
}
