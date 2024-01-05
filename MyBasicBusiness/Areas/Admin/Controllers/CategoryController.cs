using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBasicBusiness.Models;
using MyBasicBusiness.Repositories;

namespace MyBasicBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitOfWork = db;

        }
        public IActionResult Index()
        {
            List<Category> Categories = _unitOfWork.Category.GetAll().ToList();
            return View(Categories);
        }
        [Authorize]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DeleteCategory(int id)
        {
            Category category = _unitOfWork.Category.Get(u => u.Id == id);
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Save();
            return View(category);
        }
        [Authorize]
        public IActionResult EditCategory(int id)
        {

            Category category = _unitOfWork.Category.Get(u => u.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
