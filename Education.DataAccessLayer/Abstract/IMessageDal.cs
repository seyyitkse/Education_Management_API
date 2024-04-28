using Education.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace Education.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        List<Message> GetListByFilter(Expression<Func<Message, bool>> filter);
    }
}
