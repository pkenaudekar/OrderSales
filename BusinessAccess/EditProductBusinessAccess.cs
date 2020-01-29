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
    public class EditProductBusinessAccess
    {
        private EditProductDataAccess _editProductDA;

        public EditProductBusinessAccess()
        {
            _editProductDA = new EditProductDataAccess();
        }

        public AddProductBE GetProductById(int productId)
        {
            try
            {
                return _editProductDA.GetProductById(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProducts(AddProductBE NewProduct)
        {
            try
            {
                _editProductDA.UpdateProducts(NewProduct);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
