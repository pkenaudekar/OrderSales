using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntities;
using DataAccess;

namespace BusinessAccess
{
    public class CustomerBusinessAccess
    {
        private CustomerDataAccess _customerDA, _customerTypeDA;

        public CustomerBusinessAccess()
        {
            _customerDA = new CustomerDataAccess();
            _customerTypeDA = new CustomerDataAccess();
        }

        public List<CustomerBE> GetAllCustomers()
        {
            try
            {
                return _customerDA.GetAllCustomers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CustomerBE> GetAllCustomerTypes()
        {
            try
            {
                return _customerTypeDA.GetAllCustomerType();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
