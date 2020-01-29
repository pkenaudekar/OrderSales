using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class OrderRequestBE
    {
        //Automatic Prperties
        public int? CustomerId { get; set; }
        public int? CustomerTypeId { get; set; }
        public DateTime? OrderDate { get; set; }
               
    }


}
