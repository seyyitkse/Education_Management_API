using Education.BusinessLayer.Abstract;
using Education.DataAccessLayer.Abstract;
using Education.EntityLayer.Concrete;
using System.Text;

namespace Education.BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        //bolum adı icin ozel kod olusturma islemi yapıldı
        public string GenerateDepartmentCode(string departmentName)
        {
            string[] words = departmentName.Split(' ');

            StringBuilder codeBuilder = new StringBuilder();

            foreach (string word in words)
            {
                if (word.Length <= 3)
                {
                    codeBuilder.Append(word.ToUpper());
                }
                else 
                {
                    codeBuilder.Append(word.Substring(0, 3).ToUpper());
                }
            }
            return codeBuilder.ToString();
        }

        public void TDelete(Department entity)
        {
            _departmentDal.Delete(entity);
        }

        public Department TGetById(int id)
        {
            return _departmentDal.GetById(id);
        }

        public List<Department> TGetList()
        {
            return _departmentDal.GetList();
        }

        public void TInsert(Department entity)
        {
            _departmentDal.Insert(entity);
        }

        public void TUpdate(Department entity)
        {
            _departmentDal.Update(entity);
        }
    }
}
