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
    public class AddProductBusinessAccess
    {
        private AddProductDataAccess _addProductDA;

        public AddProductBusinessAccess()
        {
            _addProductDA = new AddProductDataAccess();
        }

        public List<AddProductBE> GetAllCategories()
        {
            try
            {
                return _addProductDA.GetAllCategories();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertProduct(AddProductBE NewProduct)
        {
            try
            {
                _addProductDA.InsertProducts(NewProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

