using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.Abstract
{
    public interface IDepartmentDal:IGenericDal<Department>
    {
        public Department GetDepartmentByName(string departmentName);
    }
}
