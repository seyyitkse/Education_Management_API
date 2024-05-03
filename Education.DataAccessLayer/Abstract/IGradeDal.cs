using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.Abstract
{
    public interface IGradeDal:IGenericDal<Grade>
    {
        List<Grade> GetGradesByStudentId(int studentId);
    }
}
