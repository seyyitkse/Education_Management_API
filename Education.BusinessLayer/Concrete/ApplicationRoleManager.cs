using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class ApplicationRoleManager : IApplicationRoleService
    {
        readonly IApplicationRoleDal _applicationRoleDal;

        public ApplicationRoleManager(IApplicationRoleDal applicationRoleDal)
        {
            _applicationRoleDal = applicationRoleDal;
        }

        public void TDelete(ApplicationRole entity)
        {
            _applicationRoleDal.Delete(entity);
        }

        public ApplicationRole TGetById(int id)
        {
            return _applicationRoleDal.GetById(id);
        }

        public List<ApplicationRole> TGetList()
        {
            return _applicationRoleDal.GetList();
        }

        public void TInsert(ApplicationRole entity)
        {
            _applicationRoleDal.Insert(entity);
        }

        public void TUpdate(ApplicationRole entity)
        {
            _applicationRoleDal.Update(entity);
        }
    }
}
