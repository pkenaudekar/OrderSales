using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class OrderResponseBE
    {
        //Automatic Prperties
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerTypeName { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderDetailsBE> OrderDetails { get; set; }

    }
}
