using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiDemo.Controllers;
using WebApiDemo.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Configuration;
using Rhino.Mocks;
using NUnit.Framework;



namespace Customer.UnitTests
{
   [TestFixture]
    public class CustomerControllerFixture

    {
        private CustomersController controller;

        [Test]
        public void NonMock()
        {
            //  var result = controller.GetAllCustomers() as List<WebApiDemo.Models.Customer>;
            //var customers = new List<WebApiDemo.Models.Customer>(); 
            //var testCustomers = GetTestCustomers();
            //customers = testCustomers;
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
