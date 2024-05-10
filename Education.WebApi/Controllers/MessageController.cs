using Education.BusinessLayer.Concrete;
using Education.DataAccessLayer.Abstract;
using Education.DataAccessLayer.EntityFramework;
using Education.EntityLayer.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Education.WebApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MessageManager _messageManager;

        public MessageController(UserManager<ApplicationUser> userManager, IMessageDal messageDal)
        {
            _userManager = userManager;
            _messageManager = new MessageManager(messageDal);
        }

        [HttpGet("Receiver/{username}")]
        public async Task<IActionResult> ReceiverMessage(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var messages = _messageManager.GetListRecevierMessages(user.Email);
            return Ok(messages);
        }

        [HttpGet("Sender/{username}")]
        public async Task<IActionResult> SenderMessage(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var messages = _messageManager.GetListSenderMessages(user.Email);
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var message = _messageManager.TGetById(id);
            if (message == null)
            {
                return NotFound("Mesaj bulunumadı");
            }

            return Ok(message);
        }

        [HttpPost("Send")]
        public async Task<IActionResult> SendMessage(Message message)
        {
            //string senderUser = "deneme1@ksumail.com";
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            //var sender = await _userManager.FindByNameAsync(senderUser);
            if (sender == null)
            {
                return BadRequest("Sender not found");
            }

            var receiver = await _userManager.FindByEmailAsync(message.Receiver);
            if (receiver == null)
            {
                return BadRequest("Receiver not found");
            }

            message.Sender = sender.Email;
            message.SenderName = $"{sender.FirstName} {sender.LastName}";
            message.ReceiverName = $"{receiver.FirstName} {receiver.LastName}";
            message.Date = DateTime.Now;

            _messageManager.TInsert(message);
            return Ok("Message sent successfully");
        }
    }
}
