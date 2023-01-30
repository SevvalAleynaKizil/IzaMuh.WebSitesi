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
    public class AboutService: Repository<About> ,IAboutService
    {
        public AboutService(IzaContext context) : base(context)
        {
        }
    }
}