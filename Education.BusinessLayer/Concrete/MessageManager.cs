using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;
using System.Linq.Expressions;

namespace Education.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListByFilter(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.GetListByFilter(filter);
        }

        public List<Message> GetListRecevierMessages(string p)
        {
            return _messageDal.GetListByFilter(x => x.Receiver == p);
        }

        public List<Message> GetListSenderMessages(string p)
        {
            return _messageDal.GetListByFilter(x => x.Sender == p);
        }

        public void TDelete(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetList()
        {
            return _messageDal.GetList();
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
