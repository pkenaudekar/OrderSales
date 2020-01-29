using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntities;

namespace DataAccess
{   
    public class CustomerDataAccess: BaseDataAccess
    {
        //private SqlConnection _connection;
        //private string _connectionString;
        //public CustomerDataAccess()
        //{
        //    _connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
        //}

        public List<CustomerBE> GetAllCustomers()
        {
            List<CustomerBE> customers = new List<CustomerBE>();
            using(_connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT c.*, ct.CustomerTypeName FROM Customer c " +
                            "INNER JOIN CustomerType ct " +
                            "ON c.CustomerTypeId = ct.CustomerTypeId";
                SqlCommand command = new SqlCommand(query, _connection);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader(); 
                    while(reader.Read())
                    {
                        CustomerBE customer = new CustomerBE();
                        customer.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                        customer.FirstName = Convert.ToString(reader["FirstName"]);
                        customer.LastName = Convert.ToString(reader["LastName"]);
                        customer.Title = Convert.ToString(reader["Title"]);
                        customer.CustomerTypeID = Convert.ToInt32(reader["CustomerTypeID"]);
                        customer.Address = Convert.ToString(reader["Address"]);
                        customer.City = Convert.ToString(reader["City"]);
                        customer.State = Convert.ToString(reader["State"]);
                        customer.Country = Convert.ToString(reader["Country"]);
                        customer.Pincode = Convert.ToString(reader["Pincode"]);
                        customer.Email = Convert.ToString(reader["Email"]);
                        customer.Phone = Convert.ToString(reader["Phone"]);
                        customer.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);

                        //Adding object to the list
                        customers.Add(customer);
                    }
                    reader.Close();
                    return customers;
                }
                catch(Exception)
                {
                    throw;
                }
                
            }
        }

        public List<CustomerBE> GetAllCustomerType()
        {
            List<CustomerBE> customersType = new List<CustomerBE>();
            using (_connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM CustomerType";
                SqlCommand command = new SqlCommand(query, _connection);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CustomerBE customerType = new CustomerBE();
                        customerType.CustomerTypeID = Convert.ToInt32(reader["CustomerTypeID"]);
                        customerType.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                        //Adding object to the list
                        customersType.Add(customerType);
                    }
                    reader.Close();
                    return customersType;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }
    }
}
