using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string ParkCode { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public IList<Park> Parks { get; set; }
 
    }
}
