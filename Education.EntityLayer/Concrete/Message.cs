using System.ComponentModel.DataAnnotations;

namespace Education.EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        public string? Receiver { get; set; }
        public string? ReceiverName { get; set; }
        public string? Sender { get; set; }
        public string? SenderName { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime Date { get; set; }
    }
}
