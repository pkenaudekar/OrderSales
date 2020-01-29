using BusinessEntities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class OrderBusinessAccess
    {
        private OrderDataAccess _orderDA;

        public OrderBusinessAccess()
        {
            _orderDA = new OrderDataAccess();
        }

        public List<OrderResponseBE> GetAllOrder(OrderRequestBE obj)
        {
            try
            {
                return _orderDA.GetAllOrder(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrderResponseBE GetOrderById(int orderProductId)
        {
            try
            {
                OrderResponseBE response = _orderDA.GetOrderById(orderProductId);
                response.OrderDetails = _orderDA.GetOrderDetails(orderProductId);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
