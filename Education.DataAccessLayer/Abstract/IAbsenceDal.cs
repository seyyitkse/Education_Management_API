using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.Abstract
{
    public interface IAbsenceDal : IGenericDal<Absence>
    {
        void Insert(Education.DtoLayer.Dtos.AbsenceDto.CreateAbsenceDto absenceDto);
    }
}
