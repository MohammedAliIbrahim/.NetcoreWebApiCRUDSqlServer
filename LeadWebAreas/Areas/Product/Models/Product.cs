using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadCoreAreas.Models
{
    public class product
    {


        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
    }
}
