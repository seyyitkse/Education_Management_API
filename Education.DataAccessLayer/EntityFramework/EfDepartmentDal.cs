using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfDepartmentDal:GenericRepository<Department>, IDepartmentDal
    {
        private readonly AppDbContext _context;

        public EfDepartmentDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            return _context.Departments.FirstOrDefault(d => d.DepartmentName == departmentName);
        }
    }

}
