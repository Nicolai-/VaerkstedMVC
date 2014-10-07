using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers;
using System.Web.Mvc;
using Repository.Concrete.Entities;

namespace UnitTests
{
    [TestClass]
    public class UnitTest_CustomerController
    {
        [TestMethod]
        public void CanGetAllCustomers()
        {

            //Arrange

            Mock<IGenericRepository<Customer>> mock = new Mock<IGenericRepository<Customer>>();

            IQueryable<Customer> customers = (new List<Customer>
            {
                new Customer { Id = 1, Name = "Jørgen Hansen", Company = "Jørgen Hansen Biler", Phone = 75467589 },
                new Customer { Id = 2, Name = "Klaus Jensen", Phone = 55446677 },
                new Customer { Id = 3, Name = "Jakob Jensen", Phone = 33333333 }
            }).AsQueryable();
            mock.Setup(m => m.GetAll()).Returns(customers);

            CustomerController controller = new CustomerController(mock.Object);

            // Act
            var result = controller.GetCustomers() as ViewResult;
            var custs = ((IEnumerable<Customer>)result.ViewData.Model).ToArray();

            //Assert
            Assert.AreEqual(3, custs.Count());
            Assert.AreEqual("Klaus Jensen", custs[1].Name);
        }
    }
}
