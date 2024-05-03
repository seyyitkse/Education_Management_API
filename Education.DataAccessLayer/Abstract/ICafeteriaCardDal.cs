using Education.EntityLayer.Concrete;

namespace Education.DataAccessLayer.Abstract
{
    public interface ICafeteriaCardDal:IGenericDal<CafeteriaCard>
    {
        Task<CafeteriaCard> FindByCardNumberAsync(long cardNumber);
    }
}
