using Education.BusinessLayer.Abstract;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeteriaCardController : ControllerBase
    {
        private readonly ICafeteriaCardService _cafeteriaCardService;
        //kullanıcı idye gore kart bilgisi gelecek
        public CafeteriaCardController(ICafeteriaCardService cafeteriaCardService)
        {
            _cafeteriaCardService = cafeteriaCardService;
        }

        [HttpGet]
        public IActionResult CafeteriaCardList()
        {
            var values = _cafeteriaCardService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddCafeteriaCard(CafeteriaCard CafeteriaCard)
        {
            _cafeteriaCardService.TInsert(CafeteriaCard);
            return Ok();
        }
        [HttpPut("DeductBalance")]
        public async Task<IActionResult> DeductBalanceAsync(long cardNumber)
        {
            int cook = 30;
            var result = await _cafeteriaCardService.DeductBalanceAsync(cardNumber, cook);

            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message, NewBalance = result.NewBalance });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("LoadBalance")]
        public async Task<IActionResult> LoadBalance(long cardNumber, int amount)
        {
            var result = await _cafeteriaCardService.LoadBalanceAsync(cardNumber, amount);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("TransferBalance")]
        public async Task<IActionResult> TransferBalance(long fromCardNumber, long toCardNumber, int amount)
        {
            var result = await _cafeteriaCardService.TransferBalanceAsync(fromCardNumber, toCardNumber, amount);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getCafeteriaCard")]
        public async Task<IActionResult> GetCafeteriaCard(int userID)
        {
            var cafeteriaCard = await _cafeteriaCardService.FindByApplicationUserIDAsync(userID);

            if (cafeteriaCard != null)
            {
                return Ok(cafeteriaCard);
            }
            else
            {
                return NotFound( "Belirtilen kullanıcı kimliğiyle eşleşen bir yemek kartı bulunamadı."); 
            }
        }
    }
}
