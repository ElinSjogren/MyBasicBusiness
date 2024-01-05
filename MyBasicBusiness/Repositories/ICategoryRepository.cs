using MyBasicBusiness.Models;
using System.Linq.Expressions;

namespace MyBasicBusiness.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
