using Xunit;
using FakeItEasy;
using WebApiDemo.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.UnitTesting
{
    public class CustomerControllerTests
    {
        private readonly ICustomerRepository _customerrepo;
        [Fact]
        public void Test_to_check_if_controller_works()
        {

            _customerrepo = A.Fake<ICustomerRepository>;
            //int count = 5;
            //var fakeCustomers = A.CollectionOfDummy<WebApiDemo.Models.Customer>(count).AsEnumerable();
            //var dataStore = A.Fake<WebApiDemo.Data>();
            //    A.CallTo(() => dataStore.GetAllCustomers()).Return(Task.FromResult(fakeCustomers));
            //var controller = new CustomersController(datastore);
        }
    }
}