using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersMicroservice
{
    public class Requirement
    {  
        [key]
        public int id { get; set; }
        public string PropertyType { get; set; }
        public int Budget { get; set; }
        public string Locality { get; set; }
    }
}
