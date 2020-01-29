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
    public class ProductBusinessAccess
    {
        private ProductDataAccess _productDA;

        public ProductBusinessAccess()
        {
            _productDA = new ProductDataAccess();
        }

        public List<ProductBE> GetAllProducts()
        {
            try
            {
                return _productDA.GetAllProducts();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
