using Business.Abstract;
using Business.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class YorumlarController : Controller
    {
        private readonly ICommentsService service;

        public YorumlarController(ICommentsService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("/Admin/Yorumlar")]

        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet]
        [Route("/Admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id, Comments comments)
        {
            ViewBag.Message = service.Update(comments);
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Yorumlar/Response/{Id}")]
        public IActionResult Response(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Yorumlar/Response/{Id}")]
        public IActionResult Response(int Id, Comments comments)
        {
            ViewBag.Message = service.Update(comments);
            return View(service.GetById(x => x.Id == Id));
        }

        [HttpGet]
        [Route("/admin/Yorumlar/Delete/{Id}")]

        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/Admin/Yorumlar");
        }
    }

}
