using Education.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace Education.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetListSenderMessages(string p);
        List<Message> GetListRecevierMessages(string p);
        List<Message> GetListByFilter(Expression<Func<Message, bool>> filter);
    }
}
