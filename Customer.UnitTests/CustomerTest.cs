using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiDemo.Controllers;
using WebApiDemo.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Configuration;


namespace Customer.UnitTests
{
    [TestClass]
    public class CustomerTest

    {
        //private Mock<IRoleRepository> _roleRepository;

        //[SetUp]
        //public void SetUp()
        //{
        //    _roleRepository = new Mock<IRoleRepository>();

        //  }

        [TestMethod]
        public void NonMock()
        {
           // var result = controller.GetAllCustomers() as List<WebApiDemo.Models.Customer>;
            var customers = new List<WebApiDemo.Models.Customer>();
            var testCustomers = GetTestCustomers();
            customers = testCustomers;
        }

      
        [TestMethod]
        public void Check_Customer_not_null()
        {
            var testCustomers = GetTestCustomers();
        
           // Assert.IsTrue(testCustomers.Count > 0);
            Assert.IsNotNull(testCustomers);
            Assert.AreEqual(testCustomers.Count,4);
          
        }
       

        [TestMethod]
        public void GetCustomer_ShouldReturnCorrectCustomer()
        {
            var testCustomers = GetTestCustomers();
             var controller = new CustomersController();

            var result = controller.GetCustomersById(4) as WebApiDemo.Models.Customer;
            Assert.IsNotNull(result);
            Assert.AreEqual(testCustomers[3].CustomerName, result.CustomerName);
        }

      

        [TestMethod]
        public void GetCustomer_ShouldNotFindCustomer()
        {
            var controller = new CustomersController();

            var result = controller.GetCustomersById(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<WebApiDemo.Models.Customer> GetTestCustomers()
        {
            var testCustomers = new List<WebApiDemo.Models.Customer>();
            testCustomers.Add(new WebApiDemo.Models.Customer { CustomerId = 1111, CustomerName = "Rick Thomas", CustomerAddress = "1111 Street" });
            testCustomers.Add(new WebApiDemo.Models.Customer { CustomerId = 2222, CustomerName = "James Skit", CustomerAddress = "2222 Street" });
            testCustomers.Add(new WebApiDemo.Models.Customer { CustomerId = 3333, CustomerName = "Ken Vaun", CustomerAddress = "3333 Street" });
            testCustomers.Add(new WebApiDemo.Models.Customer { CustomerId = 4444, CustomerName = "Wei Chung", CustomerAddress = "4444 Street" });


            return testCustomers;
        }
    }
}
