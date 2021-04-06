using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mitek_API.Controllers;
using Mitek_API.Db;
using Mitek_API.Models;
using NSubstitute;
using System;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Products productsController;
        IDbContext _context;
        Product product = new Product
        {
            Id = 1,
            Name = "Test",
            Category = 1,
            Description = "Some description"
        };

        [TestInitialize]
        public void Initialize()
        {
            _context = Substitute.For<IDbContext>();
            productsController = new Products(_context);
        }

        [TestMethod]
        public void ProductsController_Add_Success()
        {
            _context.AddProduct(default).ReturnsForAnyArgs(Task.FromResult(1));
            var result = productsController.Post(product);
            Assert.AreEqual(product, result.Result);
        }
    }
}
