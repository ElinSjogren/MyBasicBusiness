using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBasicBusiness.Data;
using MyBasicBusiness.Models;
using MyBasicBusiness.Repositories;


namespace MyBasicBusiness.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork db)
        {
            _unitOfWork = db;

        }

        public IActionResult Index()
        {
            List<Product> Products = _unitOfWork.Product.GetAll().ToList();
            return View(Products);
        }
        [Authorize]
        public IActionResult AddProduct()
        {

            List<Category> Categories = _unitOfWork.Category.GetAll().ToList();

            ViewBag.Categories = Categories;

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _unitOfWork.Product.Add(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _unitOfWork.Product.Get(u => u.Id == id);
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            return View(id);
        }
        [Authorize]
        public IActionResult EditProduct(int id)
        {

            Product product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            _unitOfWork.Product.Update(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
