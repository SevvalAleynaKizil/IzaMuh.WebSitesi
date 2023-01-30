using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Service
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public string Details { get; set; }
        public IList<Comments> Comments { get; set; }
    }
}
