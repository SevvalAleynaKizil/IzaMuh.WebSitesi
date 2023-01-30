using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ServiceService: Repository<Service>,IServiceService
    {
        public ServiceService(IzaContext context):base(context) 
        { 
        }
    }
}
