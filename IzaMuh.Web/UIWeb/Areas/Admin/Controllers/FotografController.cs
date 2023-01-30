using Business.Abstract;
using Business.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.Design;
using System.Security.Cryptography.Xml;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize]
    public class FotografController : Controller
    {
        private readonly IPhotoService photoservice;

        public FotografController(IPhotoService photoservice)
        {
            this.photoservice = photoservice;
        }
        public IActionResult Index()
        {
            return View(photoservice.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Photo photo, IFormFile file)
        {

            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);//acb.jpg
                string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };

                if (IzinverilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }

                    photo.Name = RastgeleAd;
                    ViewBag.Message = photoservice.Insert(photo);

                }
                else
                {
                    ViewBag.Error = "Lütfen .jpg , .jpeg , veya .png uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Dosya Seçiniz";
            }
            return View();
        }

        [HttpGet]
        [Route("/Admin/Fotograf/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(photoservice.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Fotograf/Update/{Id}")]
        public IActionResult Update(int Id, Photo photo, IFormFile file)
        {

            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    photo.Name = RastgeleAd;
                    ViewBag.Message = photoservice.Update(photo);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Message = photoservice.Update(photo);
            }
            return View(photoservice.GetById(x => x.Id == Id));
        }


        [HttpGet]
        [Route("/Admin/Fotograf/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            photoservice.Delete(x => x.Id == Id);
            return Redirect("/Admin/Fotograf");

        }
    }
}
