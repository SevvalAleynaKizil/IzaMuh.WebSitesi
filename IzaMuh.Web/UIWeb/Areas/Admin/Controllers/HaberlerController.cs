using Business.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class HaberlerController : Controller
    {
        private readonly INewsService newsservice;

        public HaberlerController(INewsService newsservice)
        {
            this.newsservice = newsservice;
        }
        public IActionResult Index()
        {
            return View(newsservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(News news )
        {
            ViewBag.Message = newsservice.Insert(news);
            return View();

        }

        [HttpGet]
        [Route("/Admin/Haberler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(newsservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Haberler/Update/{Id}")]
        public IActionResult Update(int Id, News news)
        {
            ViewBag.Message = newsservice.Update(news);
            return View(newsservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Haberler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = newsservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Haberler");

        }
    }
}










