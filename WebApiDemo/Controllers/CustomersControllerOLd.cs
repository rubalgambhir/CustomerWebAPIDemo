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
//using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class CustomerController : ApiController
    {
        public static IList<Customer> listCust = new List<Customer>()
        {
        };

        [AcceptVerbs("GET")]
        public Customer RPCStyleMethodFetchFirstCustomers()
        {
            return listCust.FirstOrDefault();
        }


        [HttpGet]
        [ActionName("GetAllCustomers")]
        public List<Customer> Get()
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
                    CustomerId = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    //ManagerId = Convert.ToInt32(reader.GetValue(2))
                });
            }
            return AllCustomer;
        }




        [HttpGet]
        [ActionName("GetCustomerByID")]
        public Customer Get(int id)
        {
            //return listEmp.First(e => e.ID == id);
            SqlDataReader reader = null;
            SqlConnection myConnection = new SqlConnection();

            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Select * from Customer where CustomerId=" + id + "";

            sqlCmd.Connection = myConnection;
            myConnection.Open();
            reader = sqlCmd.ExecuteReader();
            Customer cust = null;
            while (reader.Read())
            {
                cust = new Customer();
                cust.CustomerId = Convert.ToInt32(reader.GetValue(0));
                cust.Name = reader.GetValue(1).ToString();
               // emp.ManagerId = Convert.ToInt32(reader.GetValue(2));
            }
            return cust;
        }


        [HttpPost]
        public void AddCustomer(Customer customer)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO Customer (Customer_id,Customer_name) Values (@CustomerId,@Name)";
            sqlCmd.Connection = myConnection;
            sqlCmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            sqlCmd.Parameters.AddWithValue("@Name", customer.Name);
           // sqlCmd.Parameters.AddWithValue("@ManagerId", employee.ManagerId);
            myConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }


        [ActionName("DeleteCustomer")]
        public void DeleteCustomerByID(int id)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from customer where CustomerId=" + id + "";
            sqlCmd.Connection = myConnection;
            myConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            myConnection.Close();
        }
    }
}
