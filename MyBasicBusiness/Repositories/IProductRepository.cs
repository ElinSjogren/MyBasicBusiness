using MyBasicBusiness.Models;

namespace MyBasicBusiness.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
    }
}
