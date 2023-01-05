using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace WebApiDemo.Controllers
{
    public class CustomersController : ApiController
    {
        // CompanyEntities db = new CompanyEntities();

        //public IEnumerable<Customer> Get()
        //{
        //    return db.Customers.ToList();
        //   private ICustomerRepository _repository;
//private readonly ICustomerRepository _customerRepository;

        ////public CustomersController(ICustomerRepository repository)
        ////{
        ////    _repository = repository;
        ////}
        //}

        public static IList<Customer> listEmp = new List<Customer>()
        {
        };

        [AcceptVerbs("GET")]
        public Customer RPCStyleMethodFetchFirstEmployees()
        {
            return listEmp.FirstOrDefault();
        }

        [HttpGet]
        [ActionName("GetAllCustomers")]
        public List<Customer> GetAllCustomers()
        {
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];

            List<Customer> AllCustomer = new List<Customer>();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Customer";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                AllCustomer.Add(new Customer()
                {
                    CustomerId = Convert.ToInt32(reader.GetValue(1)),
                    CustomerName = reader.GetValue(2).ToString(),
                    CustomerAddress = reader.GetValue(3).ToString(),
                    age = Convert.ToInt32(reader.GetValue(4)),

                });
            }
            return AllCustomer;

        }



        [HttpGet]
        [ActionName("GetCustomerByAge")]
        public Customer GetCustomersByAge(int Age)
        // public IHttpActionResult GetCustomersById(int id)
        {
            //return listEmp.First(e => e.ID == id);
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Customer where age=" + Age + "";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Customer cust = null;
            while (reader.Read())
            {
                cust = new Customer();
                cust.CustomerId = Convert.ToInt32(reader.GetValue(1));
                cust.CustomerName = reader.GetValue(2).ToString();
                cust.CustomerAddress = reader.GetValue(3).ToString();
                cust.age = Convert.ToInt32(reader.GetValue(4));
                // emp.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }
            return cust;
            myConnection.Close();
            //if (cust == null)
            //{
            //    return NotFound();
            //}
            //return Ok(cust);
        }

        [HttpPost]
        public void AddCustomer(Customer customer)
        {
           // try
           // {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO Customer (Customer_id,Customer_name,Customer_address,age) Values (@CustomerId,@Name,@CustomerAddress,@age)";
                sqlCmd.Connection = myConnection;
                sqlCmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                sqlCmd.Parameters.AddWithValue("@Name", customer.CustomerName);
                sqlCmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                sqlCmd.Parameters.AddWithValue("@age", customer.age);
                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();
           // }
           // catch (Exception ex)
           // { Console.WriteLine(ex.Message); }
        }


        [ActionName("DeleteCustomer")]
        public void DeleteCustomerByID(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from Customer where Customer_id=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }



    }
}

