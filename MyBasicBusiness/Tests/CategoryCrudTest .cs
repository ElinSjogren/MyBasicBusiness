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
    public class CategoryCrudTest
    {

        //Arrange
        //new:a allt
        private ApplicationDbContext _dbCon;
        private CategoryController catController;

        //Controller
        //Unitofworks med mockad appdbcontext

        [SetUp]
        public void Setup()
        {
            //mocka appdbcontext, för in i ekosystemet tills den är inne i controllern.
            //riktig av resten. Enda mockade är din riktiga databas.

            Category TestCategory = new Category { Id = 12, Name = "Clothing" };
            var mockAppDb = new Mock<ApplicationDbContext>();
            _dbCon = Create.MockedDbContextFor<ApplicationDbContext>();
            UnitOfWork uw = new UnitOfWork(_dbCon);
            catController = new CategoryController(uw);
            _dbCon.Set<Category>().Add(TestCategory);
            _dbCon.SaveChanges();
        }
        //Testnamn: namnpåmethod_VadDenskaReturna_VadManSkickarin/VadDenGörNärDuGörVad
        [Test]
        public void AddCategory_SchouldReturnToActionResult_WithCategory()
        {
            Category TestCategory = new Category { Id = 13, Name = "Clothing" };
            var result = catController.AddCategory(TestCategory);
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());

        }

        [Test]
        public void AddCategory_SchouldReturnViewResult_WithNoCategory()
        {
            var result = catController.AddCategory();
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Index_ReturnsViewResult_WithListOfCategory()
        {
            // Act
            var result = catController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());

            var viewResult = result as ViewResult;
            var model = viewResult.Model;
            Assert.That(model, Is.InstanceOf<List<Category>>());

            var productList = model as List<Category>;
            Assert.That(productList.Count, Is.EqualTo(1));
        }
        [Test]
        public void DeleteCategory_SchouldReturnViewResult_WithId()
        {
            //returnera en view med ett id
            var result = catController.DeleteCategory(12);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult; 
            var obj = viewResult.Model as Category;
            Assert.That(obj.Id, Is.EqualTo(12));


        }
        [Test]
        public void EditCategory_SchouldReturnAProductObj_WithId()
        {
            //recive Id
            var result = catController.EditCategory(12);
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            var obj = viewResult.Model as Category;
            Assert.That(obj.Id, Is.EqualTo(12));

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
