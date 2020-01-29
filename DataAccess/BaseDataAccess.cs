using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseDataAccess
    {
        protected SqlConnection _connection;
        protected string _connectionString;
        public BaseDataAccess()
        {
            //_connectionString = "Data Source=.;Initial Catalog=BootcampDB;Integrated Security=True";
            _connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
    }
}
