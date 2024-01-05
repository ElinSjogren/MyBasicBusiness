using MyBasicBusiness.Data;
using MyBasicBusiness.Models;

namespace MyBasicBusiness.Repositories
{
    public class Category_Repository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public Category_Repository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
