using Business.Abstract;
using Business.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class HakkindaController : Controller
    {
       
        private readonly IAboutService aboutservice;
        public HakkindaController(IAboutService aboutservice)
        {
            this.aboutservice = aboutservice;
        }
        public IActionResult Index()
        {
            return View(aboutservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(About about)
        {
            ViewBag.Message = aboutservice.Insert(about);
            return View();

        }
        [HttpGet]
        [Route("/Admin/Hakkinda/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(aboutservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Hakkinda/Update/{Id}")]
        public IActionResult Update(int Id, About about)
        {
            ViewBag.Message = aboutservice.Update(about);
            return View(aboutservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Hakkinda/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = aboutservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Hakkinda");

        }
    }
}






