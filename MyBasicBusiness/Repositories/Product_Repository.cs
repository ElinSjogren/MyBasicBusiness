using MyBasicBusiness.Data;
using MyBasicBusiness.Models;

namespace MyBasicBusiness.Repositories
{
    public class Product_Repository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public Product_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
