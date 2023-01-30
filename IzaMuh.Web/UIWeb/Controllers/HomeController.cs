using Business.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService aboutservice;
        private readonly ICommentsService commentsservice;
        private readonly INewsService newsservice;
        private readonly IPhotoService photoservice;
        private readonly IServiceService serviceservice;
        private readonly IUsersService usersservice;
        private readonly IzaContext db;

        public HomeController(IAboutService aboutservice, ICommentsService commentsservice, INewsService newsservice, IPhotoService photoservice, IServiceService serviceservice, IUsersService usersservice, IzaContext db)
        {
            this.aboutservice = aboutservice;
            this.commentsservice = commentsservice;
            this.newsservice = newsservice;
            this.photoservice = photoservice;
            this.serviceservice = serviceservice;
            this.usersservice = usersservice;
            this.db = db;
        }

        public IActionResult Index(News news, Service service, About about, Photo photo)
        {
            var tuple = Tuple.Create(db.News.ToList(), db.Service.ToList(), db.About.ToList(), db.Photo.ToList());
            return View(tuple);
        }


    }
}
