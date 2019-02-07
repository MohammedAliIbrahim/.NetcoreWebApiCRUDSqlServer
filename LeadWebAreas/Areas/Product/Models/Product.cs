using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadCoreAreas.Models
{
    public class product
    {


        public int Id { get; set; }

        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public int IsActive { get; set; }
    }
}
