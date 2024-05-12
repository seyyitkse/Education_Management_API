using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.Concrete;
using Education.DtoLayer.Dtos.CafeteriaCardDto;
using Education.EntityLayer.Concrete;

namespace Education.BusinessLayer.Concrete
{
    public class CafeteriaCardManager : ICafeteriaCardService
    {
        readonly ICafeteriaCardDal _cafeteriaCardDal;
        private readonly AppDbContext _context;

        public CafeteriaCardManager(ICafeteriaCardDal cafeteriaCardDal, AppDbContext context)
        {
            _cafeteriaCardDal = cafeteriaCardDal;
            _context = context;
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

        public async Task<CardTransactionResult> LoadBalanceAsync(long cardNumber, int amount)
        {
            var card = await _cafeteriaCardDal.FindByCardNumberAsync(cardNumber);

            if (card == null)
            {
                return new CardTransactionResult
                {
                    IsSuccess = false,
                    Message = "Yemek kartı bulunamadı."
                };
            }

            // Bakiye artırma işlemi
            card.Balance += amount;
            _cafeteriaCardDal.Update(card);

            return new CardTransactionResult
            {
                IsSuccess = true,
                Message = "Bakiye yükleme işlemi başarılı.",
                NewBalance = card.Balance
            };
        }
        public async Task<CardTransactionResult> TransferBalanceAsync(long fromCardNumber, long toCardNumber, int amount)
        {
            var fromCard = await _cafeteriaCardDal.FindByCardNumberAsync(fromCardNumber);
            var toCard = await _cafeteriaCardDal.FindByCardNumberAsync(toCardNumber);

            if (fromCard == null || toCard == null)
            {
                return new CardTransactionResult
                {
                    IsSuccess = false,
                    Message = "Yemek kartlarından biri bulunamadı."
                };
            }

            if (fromCard.Balance < amount)
            {
                return new CardTransactionResult
                {
                    IsSuccess = false,
                    Message = "Transfer yapmak için yeterli bakiye yok."
                };
            }

            fromCard.Balance -= amount;
            toCard.Balance += amount;

            _cafeteriaCardDal.Update(fromCard);
            _cafeteriaCardDal.Update(toCard);

            return new CardTransactionResult
            {
                IsSuccess = true,
                Message = "Bakiye transferi başarılı."
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
        public async Task<CafeteriaCard> FindByApplicationUserIDAsync(int applicationUserID)
        {
            return  _context.CafeteriaCards.FirstOrDefault(c => c.ApplicationUserID == applicationUserID);
        }
    }
}