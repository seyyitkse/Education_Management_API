using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.DtoLayer.Dtos.CafeteriaCardDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class CafeteriaCardManager : ICafeteriaCardService
    {
        readonly ICafeteriaCardDal _cafeteriaCardDal;
        public CafeteriaCardManager(ICafeteriaCardDal cafeteriaCardDal)
        {
            _cafeteriaCardDal = cafeteriaCardDal;
        }

        public async Task<CardTransactionResult> DeductBalanceAsync(long cardNumber, int amount)
        {
            var card = await _cafeteriaCardDal.FindByCardNumberAsync(cardNumber);

            if (card == null)
            {
                return new CardTransactionResult
                {
                    Message = "Yemek kartı bulunamadı.",
                    IsSuccess = false
                };
            }

            if (card.Balance < amount)
            {
                return new CardTransactionResult
                {
                    IsSuccess = false,
                    Message = "Kart bakiyesi yetersiz"
                };
            }

            card.Balance -= amount;
            _cafeteriaCardDal.Update(card);

            return new CardTransactionResult
            {
                IsSuccess = true,
                Message = "Geçiş başarılı",
                NewBalance = card.Balance
            };
        }


        public void TDelete(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Delete(entity);
        }

        public CafeteriaCard TGetById(int id)
        {
            return _cafeteriaCardDal.GetById(id);
        }

        public List<CafeteriaCard> TGetList()
        {
            return _cafeteriaCardDal.GetList();
        }

        public void TInsert(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Insert(entity);
        }

        public void TUpdate(CafeteriaCard entity)
        {
            _cafeteriaCardDal.Update(entity);
        }
    }
}