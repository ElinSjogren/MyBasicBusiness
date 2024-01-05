using System.Linq.Expressions;

namespace MyBasicBusiness.Repositories
{
    public interface IRepository<T> where T : class
    {
        //T-Category or product
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
    }
}
