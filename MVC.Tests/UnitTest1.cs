using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using MVC.Controllers;
using MVC.Models;
using System.Web.Http.Results;
namespace MVC.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProductGetAllProducts()
        {
            var controller = new ProductsController();
            var response = controller.GetProducts();
            var contentResult = response as OkNegotiatedContentResult<Product>;
            // Assert the result  
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ProductId);
        }
        [TestMethod]
        public void GetProductNotFound()
        {
            // Set up Prerequisites   
            var controller = new ProductsController();
            // Act  
            IHttpActionResult actionResult = controller.GetProduct(100);
            // Assert  
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void AddProductTest()
        {
            // Arrange  
            var controller = new ProductsController();
            Product Produ = new Product
            {
                ProductName = "Test Product",
            };
            // Act  
            IHttpActionResult actionResult = controller.PostProduct(Produ);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Product>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }

        //[TestMethod]
        //public void UpdateProductTest()
        //{
        //    // Arrange  
        //    var controller = new ProductsController();
        //    Product Produ = new Product
        //    {
        //        ProductId = 4,
        //        ProductName = "Test Product",
        //    };
        //    // Act  
        //    IHttpActionResult actionResult = controller.PutProduct(Produ,Produ);
        //    var contentResult = actionResult as NegotiatedContentResult<Product>;
        //    Assert.IsNotNull(contentResult);
        //    Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
        //    Assert.IsNotNull(contentResult.Content);
        //}
    }
}
