using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void TDelete(Department entity)
        {
            _departmentDal.Delete(entity);
        }

        public Department TGetById(int id)
        {
            return _departmentDal.GetById(id);
        }

        public List<Department> TGetList()
        {
            return _departmentDal.GetList();
        }

        public void TInsert(Department entity)
        {
            _departmentDal.Insert(entity);
        }

        public void TUpdate(Department entity)
        {
            _departmentDal.Update(entity);
        }
    }
}
