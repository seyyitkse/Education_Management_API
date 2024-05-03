using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Abstract
{
    public interface IGradeService:IGenericService<Grade>
    {
        List<Grade> GetGradesByStudentId(int studentId);
    }
}
