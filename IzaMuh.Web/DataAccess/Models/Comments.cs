using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Response { get; set; } = "";
        public bool Status { get; set; } = false;
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public Service Service { get; set; }
       

    }
}
