using Education.BusinessLayer.Abstract;
using Education.BusinessLayer.Concrete;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CafeteriaCardController : ControllerBase
    {
        ICafeteriaCardService _cafeteriaCardService;

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
        [HttpDelete]
        public IActionResult DeleteCafeteriaCard(int id)
        {
            var values = _cafeteriaCardService.TGetById(id);
            _cafeteriaCardService.TDelete(values);
            return Ok();
        }
        [HttpPut("DeductBalance")]
        public async Task<IActionResult> DeductBalanceAsync(int cardNumber, int amount)
        {
            var result = await _cafeteriaCardService.DeductBalanceAsync(cardNumber, amount);

            if (result.IsSuccess)
            {
                return Ok(new { Message = result.Message, NewBalance = result.NewBalance });
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCafeteriaCard(int id)
        {
            var values = _cafeteriaCardService.TGetById(id);
            return Ok(values);
        }
    }
}
