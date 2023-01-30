using Business.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Business.Concrete;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class KullaniciController : Controller
    {
        private readonly IUsersService userservice;
        public KullaniciController(IUsersService userservice)
        {
            this.userservice = userservice;
        }
        public IActionResult Index()
        {
            return View(userservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Users users, string sifre)
        {
            sifre = users.Password;

            SHA256Managed sha256 = new SHA256Managed();
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(sifre);

            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));
            users.Password = sifreliVeri;
            ViewBag.Message = userservice.Insert(users);
            return View();

        }
        [HttpGet]
        [Route("/Admin/Kullanici/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(userservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Kullanici/Update/{Id}")]
        public IActionResult Update(int Id, Users users, string sifre)
        {
            sifre = users.Password;

            SHA256Managed sha256 = new SHA256Managed();
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(sifre);

            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));
            users.Password = sifreliVeri;
            ViewBag.Message = userservice.Update(users);
            return View(userservice.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Kullanici/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = userservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Kullanici");

        }
    }
}
