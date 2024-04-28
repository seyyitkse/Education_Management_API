using Education.DtoLayer.Dtos.AbsenceDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Abstract
{
    public interface IAbsenceService : IGenericService<Absence>
    {
        void TInsert(CreateAbsenceDto absenceDto);
    }
}
