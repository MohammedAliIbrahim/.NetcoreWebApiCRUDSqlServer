using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadCoreAreas.Models
{
    public class store
    {



        public int StoreId { get; set; }
     
        public string StoreName { get; set; }
        public ICollection<product> Products { get; set; }

    }
}
