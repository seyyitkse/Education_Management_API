using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class ApplicationUserManager : IApplicationUserService
    {
        readonly IApplicationUserDal _applicationUserDal;

        public ApplicationUserManager(IApplicationUserDal applicationUserDal)
        {
            _applicationUserDal = applicationUserDal;
        }

        public void TDelete(ApplicationUser entity)
        {
            _applicationUserDal.Delete(entity);
        }

        public ApplicationUser TGetById(int id)
        {
            return _applicationUserDal.GetById(id);
        }

        public List<ApplicationUser> TGetList()
        {
            return _applicationUserDal.GetList();
        }

        public void TInsert(ApplicationUser entity)
        {
            _applicationUserDal.Insert(entity);
        }

        public void TUpdate(ApplicationUser entity)
        {
            _applicationUserDal.Update(entity);
        }
    }
}
