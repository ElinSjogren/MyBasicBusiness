using MyBasicBusiness.Data;

namespace MyBasicBusiness.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Product { get; private set; }
        public ICategoryRepository Category { get; private set; }
        public ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;  
            Product = new Product_Repository(_db);
            Category = new Category_Repository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
