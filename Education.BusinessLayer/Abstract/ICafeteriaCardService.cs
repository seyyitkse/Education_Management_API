using Education.DtoLayer.Dtos.CafeteriaCardDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Abstract
{
    public interface ICafeteriaCardService : IGenericService<CafeteriaCard>
    {
        Task<CardTransactionResult> DeductBalanceAsync(long mealCardId, int amount);
        Task<CardTransactionResult> LoadBalanceAsync(long cardNumber, int amount);
        Task<CardTransactionResult> TransferBalanceAsync(long fromCardNumber, long toCardNumber, int amount);
        Task<CafeteriaCard> FindByApplicationUserIDAsync(int applicationUserID);
    }
}
