using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class NewsService:Repository<News>,INewsService
    {
        public NewsService(IzaContext context):base(context)
        {

        }
    }
}
