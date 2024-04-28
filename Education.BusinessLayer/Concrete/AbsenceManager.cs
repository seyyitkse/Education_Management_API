using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.DtoLayer.Dtos.AbsenceDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class AbsenceManager : IAbsenceService
    {
        IAbsenceDal _absenceDal;

        public AbsenceManager(IAbsenceDal absenceDal)
        {
            _absenceDal = absenceDal;
        }

        public void TDelete(Absence entity)
        {
            _absenceDal.Delete(entity);
        }

        public Absence TGetById(int id)
        {
            return _absenceDal.GetById(id);
        }

        public List<Absence> TGetList()
        {
            return _absenceDal.GetList();   
        }

        public void TInsert(Absence entity)
        {
            _absenceDal.Insert(entity);
        }

        public void TInsert(CreateAbsenceDto absenceDto)
        {
            var entity = new Absence
            {
                ApplicationUserID = absenceDto.ApplicationUserID,
                LessonID = absenceDto.LessonID,
                Date = absenceDto.Date,
                DepartmentID = absenceDto.DepartmentID
            };
            _absenceDal.Insert(entity);
        }

        public void TUpdate(Absence entity)
        {
            _absenceDal.Update(entity);
        }
    }
}
