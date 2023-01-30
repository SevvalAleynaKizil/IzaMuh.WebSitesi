using Business.Abstract;
using Business.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace UIWeb.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class HizmetlerController : Controller
    {
        private readonly IServiceService serviceService;

        public HizmetlerController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        public IActionResult Index()
        {
            return View(serviceService.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Service service, IFormFile file)
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

                    service.Images = RastgeleAd;
                    ViewBag.Message = serviceService.Insert(service);

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
        [Route("/Admin/Hizmetler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(serviceService.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/Admin/Hizmetler/Update/{Id}")]
        public IActionResult Update(int Id, Service service, IFormFile file)
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
                    service.Images = RastgeleAd;
                    ViewBag.Message = serviceService.Update(service);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Message = serviceService.Update(service);
            }

            return View(serviceService.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/Admin/Hizmetler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            serviceService.Delete(x => x.Id == Id);
            return Redirect("/Admin/Hizmetler");

        }
    }
}







