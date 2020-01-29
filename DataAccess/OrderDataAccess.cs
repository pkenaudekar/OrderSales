using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDataAccess : BaseDataAccess
    {
        public List<OrderResponseBE> GetAllOrder(OrderRequestBE obj)
        {
            List<OrderResponseBE> orders = new List<OrderResponseBE>();
            using (_connection = new SqlConnection(_connectionString))
            {
                //var query = "SELECT c.*, ct.CustomerTypeName FROM Customer c " +
                //            "INNER JOIN CustomerType ct " +
                //            "ON c.CustomerTypeId = ct.CustomerTypeId";
                
                //var query = "SELECT [Order].OrderId, [Order].OrderDate, Customer.FirstName, Customer.LastName, CustomerType.CustomerTypeName, ( OrderDetail.UnitPrice* OrderDetail.Quantity ) AS TotalAmount " +
                //            "FROM (((( Customer INNER JOIN CustomerType ON Customer.CustomerTypeId = CustomerType.CustomerTypeId ) " +
                //            "INNER JOIN [Order] ON Customer.CustomerId = [Order].CustomerId ) " +
                //            "INNER JOIN OrderDetail ON[Order].OrderId= OrderDetail.ProductId )) " +
                //            "WHERE Customer.CustomerId = @customerId AND CustomerType.CustomerTypeId = @customerTypeId AND [Order].OrderDate = @orderDate";
                //SqlCommand command = new SqlCommand(query, _connection);
                
                //Connection to db passing stored procedure name
                SqlCommand command = new SqlCommand("usp_OrderDetailsOfCustomer", _connection);
                //command.CommandText = "usp_OrderDetailsOfCustomer";
                command.CommandType = CommandType.StoredProcedure;

                //InputParameters 
                command.Parameters.AddWithValue("@customerId", obj.CustomerId);
                command.Parameters.AddWithValue("@customerTypeId", obj.CustomerTypeId);
                command.Parameters.AddWithValue("@orderDate", obj.OrderDate);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderResponseBE order = new OrderResponseBE();
                        order.OrderId = Convert.ToInt32(reader["OrderId"]);
                        order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                        order.FirstName = Convert.ToString(reader["FirstName"]);
                        order.LastName = Convert.ToString(reader["LastName"]);
                        order.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                        order.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        //Adding object to the list
                        orders.Add(order);
                    }
                    reader.Close();
                    return orders;
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }

        public List<OrderDetailsBE> GetOrderDetails(int orderId)
        {
            List<OrderDetailsBE> orders = new List<OrderDetailsBE>();
            using (_connection = new SqlConnection(_connectionString))
            {

                //var query = "SELECT [Order].OrderId, Product.ProductId , Product.ProductName , Product.UnitPrice, OrderDetail.Quantity,(OrderDetail.UnitPrice * OrderDetail.Quantity) AS Total " +
                //            "FROM((( [Order] INNER JOIN OrderDetail ON [Order].OrderId = OrderDetail.OrderId) " +
                //            "INNER JOIN Product ON OrderDetail.ProductId = Product.ProductId )) " +
                //            "WHERE[Order].OrderId = orderId";
                var query = "SELECT [Order].OrderId, Product.ProductId , Product.ProductName , Product.UnitPrice, OrderDetail.Quantity,(OrderDetail.UnitPrice * OrderDetail.Quantity) AS Total FROM((( [Order] INNER JOIN OrderDetail ON[Order].OrderId = OrderDetail.OrderId) INNER JOIN Product ON OrderDetail.ProductId = Product.ProductId )) WHERE[Order].OrderId = @orderId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@orderId", orderId);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDetailsBE order = new OrderDetailsBE();
                        order.OrderId = Convert.ToInt32(reader["OrderId"]);
                        order.ProductId = Convert.ToInt32(reader["ProductId"]);
                        order.ProductName = Convert.ToString(reader["ProductName"]);
                        order.UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
                        order.Quantity = Convert.ToInt32(reader["Quantity"]);
                        order.Total = Convert.ToDouble(reader["Total"]);
                        //Adding object to the list
                        orders.Add(order);
                    }
                    reader.Close();
                    return orders;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public OrderResponseBE GetOrderById(int orderId)
        {
            using (_connection = new SqlConnection(_connectionString))
            {

                var query = "SELECT [Order].OrderId, [Order].OrderDate, Customer.FirstName, Customer.LastName, CustomerType.CustomerTypeName, ( OrderDetail.UnitPrice* OrderDetail.Quantity ) AS TotalAmount " +
                    "FROM (((( Customer INNER JOIN CustomerType ON Customer.CustomerTypeId = CustomerType.CustomerTypeId ) " +
                    "INNER JOIN [Order] ON Customer.CustomerId = [Order].CustomerId ) " + 
                    "INNER JOIN OrderDetail ON[Order].OrderId= OrderDetail.ProductId )) " +
                    "WHERE [Order].OrderId = @orderId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@orderId", orderId);
                //command.Parameters
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    OrderResponseBE order = new OrderResponseBE();
                    order.OrderId = Convert.ToInt32(reader["OrderId"]);
                    order.CustomerTypeName = Convert.ToString(reader["CustomerTypeName"]);
                    order.FirstName = Convert.ToString(reader["FirstName"]);
                    order.LastName = Convert.ToString(reader["LastName"]);
                    order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    order.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);

                    //Adding object to the list                    
                    reader.Close();

                    _connection.Close();
                    return order;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
