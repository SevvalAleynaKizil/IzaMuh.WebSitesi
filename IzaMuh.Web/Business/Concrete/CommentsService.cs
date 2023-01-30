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
    public class CommentsService : Repository<Comments>,ICommentsService
    {
        public CommentsService(IzaContext context) : base(context) 
        {
        }
    }
}
