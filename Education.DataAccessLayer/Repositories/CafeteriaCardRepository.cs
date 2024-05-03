using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer.Repositories
{
    public class CafeteriaCardRepository : ICafeteriaCardDal
    {
        private readonly AppDbContext _context;

        public CafeteriaCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CafeteriaCard> FindByCardNumberAsync(long cardNumber)
        {
            return await _context.CafeteriaCards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
        }
        public void Delete(CafeteriaCard entity)
        {
            throw new NotImplementedException();
        }


        public CafeteriaCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CafeteriaCard> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(CafeteriaCard entity)
        {
            throw new NotImplementedException();
        }

        public void Update(CafeteriaCard entity)
        {
            throw new NotImplementedException();
        }
    }
}
