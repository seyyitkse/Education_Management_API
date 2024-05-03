using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfGradeDal : GenericRepository<Grade>,IGradeDal
    {
        private readonly AppDbContext _context;

        public EfGradeDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Grade> GetGradesByStudentId(int studentId)
        {
            return _context.Grades.Where(g => g.StudentId == studentId).ToList();
        }

    }
}
