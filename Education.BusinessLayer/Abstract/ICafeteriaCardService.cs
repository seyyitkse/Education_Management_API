using Education.DtoLayer.Dtos.CafeteriaCardDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Abstract
{
    public interface ICafeteriaCardService : IGenericService<CafeteriaCard>
    {
        Task<CardTransactionResult> DeductBalanceAsync(int mealCardId, int amount);
    }
}
