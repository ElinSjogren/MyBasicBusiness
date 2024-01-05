using NUnit.Framework;
using Moq;
using MyBasicBusiness.Models;
using MyBasicBusiness.Repositories;
using MyBasicBusiness.Data;
using MyBasicBusiness.Areas.Admin.Controllers;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.AspNetCore.Mvc;



namespace MyBasicBusiness.Tests
{
    [TestFixture]
    public class ProductCrudTest
    {

        //Arrange
        //new:a allt
        private ApplicationDbContext _dbCon;
        private ProductController prodController;

        //Controller
        //Unitofworks med mockad appdbcontext

        [SetUp]
        public void Setup()
        {
            //mocka appdbcontext, för in i ekosystemet tills den är inne i controllern.
            //riktig av resten. Enda mockade är din riktiga databas.

            Product TestProduct = new Product { Id = 2, Name = "T-shirt", CategoryId = 12 };

            _dbCon = Create.MockedDbContextFor<ApplicationDbContext>();
            UnitOfWork uw = new UnitOfWork(_dbCon);
            prodController = new ProductController(uw);
            _dbCon.Set<Product>().Add(TestProduct);
            _dbCon.SaveChanges();
        }
        //Testnamn: namnpåmethod_VadDenskaReturna_VadManSkickarin/VadDenGörNärDuGörVad
        [Test]
        public void AddProduct_SchouldReturnToActionResult_WithProduct()
        {
            Product TestProduct = new Product { Id = 1, Name = "S-shirt", CategoryId = 12 };
            //Category TestCategory = new Category { Id = 12, Name = "Clothing" };
            var result = prodController.AddProduct(TestProduct);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

        }
        [Test]
        public void Index_ReturnsViewResult_WithListOfProducts()
        {
            // Act
            var result = prodController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            Assert.That(model, Is.InstanceOf<List<Product>>());

            var productList = model as List<Product>;
            Assert.That(productList.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddProduct_SchouldReturnViewResult_WithNoProduct()
        {
            var result = prodController.AddProduct();
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void DeleteProduct_SchouldReturnViewResult_WithId()
        {
            //returnera en view med ett id
            var result = prodController.DeleteProduct(2);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.Model, Is.EqualTo(2));
            
            
        }
        [Test]
        public void EditProduct_SchouldReturnAProductObj_WithId()
        {
            //recive Id
            var result = prodController.EditProduct(2);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            var obj = viewResult.Model as Product;
            Assert.That(obj.Id, Is.EqualTo(2));

        }

        [TearDown]
        public void TearDown()
        {
            _dbCon.Dispose();
        }

        //Act



        //ASsert
    }
}
