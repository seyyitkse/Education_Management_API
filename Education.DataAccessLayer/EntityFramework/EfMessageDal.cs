using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>,IMessageDal
    {
        private readonly AppDbContext _context;
        public EfMessageDal(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public List<Message> GetListByFilter(Expression<Func<Message, bool>> filter)
        {
            return _context.Set<Message>().Where(filter).ToList();
        }
    }
}
