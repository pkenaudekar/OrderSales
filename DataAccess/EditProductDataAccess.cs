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
    public class EditProductDataAccess 
    {
        private SqlConnection _connection;
        private string _connectionString;
        private SqlCommand _command;
        public EditProductDataAccess()
        {
            _connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
        }


        public AddProductBE GetProductById(int productId) //AddProductBE is been used as TypeCode reusability
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                 
                var query = "SELECT * FROM Product WHERE ProductId = @productId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@productId", productId);
                //command.Parameters
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    AddProductBE product = new AddProductBE();
                    product.ProductId = Convert.ToInt32(reader["ProductId"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                    product.UnitPrice = Convert.ToInt32(reader["UnitPrice"]);
                    product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                    product.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"]);
                    product.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                    product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);
                    
                    //Adding object to the list                    
                    reader.Close();
             
                    _connection.Close();
                    return product;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void UpdateProducts(AddProductBE NewProduct)
        {
            using (_connection = new SqlConnection(_connectionString))
            {
                _connection.Open();
                var query = "Update Product SET ProductName = @productName, CategoryId = @categoryId,UnitPrice = @unitPrice,UnitsInStock = @unitsInStock, UnitsOnOrder = @unitsOnOrder, ReorderLevel = @reorderLevel, Discontinued = @discontinue WHERE ProductId = @productId ";
                _command = new SqlCommand(query, _connection);//command object
                try
                {
                    _command.Parameters.AddWithValue("@productName", NewProduct.ProductName);
                    _command.Parameters.AddWithValue("@productId", NewProduct.ProductId);
                    _command.Parameters.AddWithValue("@categoryId", NewProduct.CategoryId);
                    _command.Parameters.AddWithValue("@unitPrice", NewProduct.UnitPrice);
                    _command.Parameters.AddWithValue("@unitsInStock", NewProduct.UnitsInStock);
                    _command.Parameters.AddWithValue("@unitsOnOrder", NewProduct.UnitsOnOrder);
                    _command.Parameters.AddWithValue("@reorderLevel", NewProduct.ReorderLevel);
                    _command.Parameters.AddWithValue("@discontinue", NewProduct.Discontinued);
                    int x = _command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
