using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DataAccessLayer.Repositories;
using Education.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Education.DataAccessLayer.EntityFramework
{
    public class EfCafeteriaCardDal : GenericRepository<CafeteriaCard>, ICafeteriaCardDal
    {
        private readonly AppDbContext _context;

        public EfCafeteriaCardDal(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CafeteriaCard> FindByCardNumberAsync(long cardNumber)
        {
            return await _context.CafeteriaCards.FirstOrDefaultAsync(c => c.CardNumber == cardNumber);
        }
    }
}
