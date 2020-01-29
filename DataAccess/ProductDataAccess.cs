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
    public class ProductDataAccess
    {
        private SqlConnection _connection;
        private string _connectionString;
        private SqlCommand _command;
        
        public ProductDataAccess()
        {
            _connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
        }

        public List<ProductBE> GetAllProducts()
        {
            List<ProductBE> products = new List<ProductBE>();
            DataSet dsResult = new DataSet();
            using (_connection = new SqlConnection(_connectionString))
            {                
                var query = "SELECT * FROM Product";
                _command = new SqlCommand(query, _connection);//command object
                try
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(query, _connection);
                    SqlDataAdapter da = new SqlDataAdapter(_command);
                    da.Fill(dsResult);

                    foreach (DataRow rows in dsResult.Tables[0].Rows)
                    {
                        ProductBE product = new ProductBE();
                        product.ProductId = Convert.ToInt32(rows["ProductId"]);
                        product.ProductName = Convert.ToString(rows["ProductName"]);
                        product.CategoryId = Convert.ToInt32(rows["CategoryId"]);
                        product.UnitPrice = Convert.ToDecimal(rows["UnitPrice"]);
                        product.UnitsInStock = Convert.ToInt32(rows["UnitsInStock"]);
                        product.UnitsOnOrder = Convert.ToInt32(rows["UnitsOnOrder"]);
                        product.ReorderLevel = Convert.ToInt32(rows["ReorderLevel"]);
                        product.Discontinued = Convert.ToBoolean(rows["Discontinued"]);

                        //Adding object to the list
                        //dsResult.Add(product);
                        products.Add(product);
                    }
                    _connection.Close();
                    return products;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        //public List<ProductBE> GetAllProducts()
        //{
        //    List<ProductBE> products = new List<ProductBE>();
        //    using (_connection = new SqlConnection(_connectionString))
        //    {
        //        var query = "SELECT * FROM Product";
        //        SqlCommand command = new SqlCommand(query, _connection);
        //        try
        //        {
        //            _connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                ProductBE product = new ProductBE();
        //                product.ProductId = Convert.ToInt32(reader["ProductId"]);
        //                product.ProductName = Convert.ToString(reader["ProductName"]);
        //                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
        //                product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
        //                product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
        //                product.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"]);
        //                product.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
        //                product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);


        //                //Adding object to the list
        //                products.Add(product);
        //            }
        //            reader.Close();

        //            return products;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }

        //    }
        //}

    }
}
