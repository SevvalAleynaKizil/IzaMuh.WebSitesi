using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;

namespace UIWeb.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService serviceservice;
        private readonly ICommentsService commentsservice;
        public ServiceController(ICommentsService commentsservice, IServiceService serviceservice, IzaContext db)
        {
            this.serviceservice = serviceservice;
            this.commentsservice = commentsservice;
        }

        [Route("/Service/Details/{Id}")]
        public IActionResult Details(int Id)
        {
            View(commentsservice.GetAll().Where(x => x.ServiceId == Id).ToList());
         
            return View(serviceservice.GetById(x => x.Id == Id));

        }
        [HttpPost]
        [Route("/Service/Details/{Id}")]
        public IActionResult Details(int Id, Comments comments)
        {
            comments.ServiceId = Id;
           
            comments.Status = false;
            comments.Id = 0;
            ViewBag.Message = commentsservice.Insert(comments);

            ViewBag.Yorumlar = commentsservice.GetAll().Where(x => x.ServiceId == Id).ToList();



            return View(serviceservice.GetById(x => x.Id == Id));



        }
    }
}
