using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace ProductionUnitTest
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductRepository> _repository;

        [TestMethod]
        public void IndexReturnsAllProducts()
        { 
            _repository = new Mock<IProductRepository>();

            List<Product> fakeproducts = new List<Product>{
                new Product {Name="Hammer", Price=121.50m, Category="Verktøy"},
                new Product {Name="Vinkelsliper", Price=1520.00m, Category ="Verktøy"},
                new Product {Name="Melk", Price=14.50m, Category ="Dagligvarer"},
                new Product {Name="Kjøttkaker", Price=32.00m, Category ="Dagligvarer"},
                new Product {Name="Brød", Price=25.50m, Category ="Dagligvarer"}
            };
            _repository.Setup(x => x.GetAll()).Returns(fakeproducts);

            var controller = new ProductController(_repository.Object);

            var result = (ViewResult) controller.Index();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)result.ViewData.Model, typeof(Product));
            Assert.IsNotNull(result, "View Result is null");
            var products = result.ViewData.Model as List<Product>;
            Assert.AreEqual(5, products.Count, "Got wrong number of products");
        }

        [TestMethod]
        public void SaveIsCalledWhenProductIsCreated()
        {
            // Arrange
            _repository = new Mock<IProductRepository>();
            _repository.Setup(x => x.Save(It.IsAny<Product>()));
            var controller = new ProductController(_repository.Object);
            // Act
            var result = controller.Create(new Product());
            // Assert
            _repository.VerifyAll();
            // test på at save er kalt et bestemt antall ganger
            // repository.Verify(x => x.Save(It.IsAny<Product>()), Times.Exactly(1));
        }
    }
}
