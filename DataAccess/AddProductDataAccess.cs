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
    public class AddProductDataAccess : BaseDataAccess
    { 
        private SqlConnection _connection;
        //private string _connectionString;
        private SqlCommand _command;
        //public AddProductDataAccess()
        //{
        //    _connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
        //}

        public void InsertProducts(AddProductBE NewProduct)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                var query = "INSERT INTO Product VALUES(@productName,@categoryId,@unitPrice,@unitsInStock,@unitsOnOrder,@reorderLevel,@discontinue)";
                _command = new SqlCommand(query, _connection);//command object
                try
                {
                    _command.Parameters.AddWithValue("@productName", NewProduct.ProductName);
                    _command.Parameters.AddWithValue("@categoryId", NewProduct.CategoryId);
                    _command.Parameters.AddWithValue("@unitPrice", NewProduct.UnitPrice);
                    _command.Parameters.AddWithValue("@unitsInStock", NewProduct.UnitsInStock);
                    _command.Parameters.AddWithValue("@unitsOnOrder", NewProduct.UnitsOnOrder);
                    _command.Parameters.AddWithValue("@reorderLevel", NewProduct.ReorderLevel);
                    _command.Parameters.AddWithValue("@discontinue", NewProduct.Discontinued);
                    _command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }       

        public List<AddProductBE> GetAllCategories()
        {
            List<AddProductBE> categorys = new List<AddProductBE>();
            using (_connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT CategoryId, CategoryName FROM Category ";
                SqlCommand command = new SqlCommand(query, _connection);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AddProductBE category = new AddProductBE();
                        category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                        category.CategoryName= Convert.ToString(reader["CategoryName"]);                       

                        //Adding object to the list
                        categorys.Add(category);
                    }
                    reader.Close();
                    return categorys;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
