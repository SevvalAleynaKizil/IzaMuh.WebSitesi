using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Business.Abstract;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("Admin")]
    public class GirisController : Controller
    {
        private readonly IUsersService service;

        public GirisController(IUsersService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Username, string Password, string sifre)
        {
            sifre = Password;

            SHA256Managed sha256 = new SHA256Managed();
            byte[] bitDizisi = System.Text.Encoding.UTF8.GetBytes(sifre);

            string sifreliVeri = Convert.ToBase64String(sha256.ComputeHash(bitDizisi));
            Password = sifreliVeri;
            var BulunanUser = service.GetById(x => x.Username == Username && x.Password == Password);

            if (BulunanUser != null)
            {
                var Claims = new List<Claim>
                    {

                     new Claim("Id", BulunanUser.Id.ToString())
                    };
                var UserIdentity = new ClaimsIdentity(Claims, "YoneticiClaims");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                HttpContext.SignInAsync(principal);
                return Redirect("/Admin/Fotograf");
            }
            else
            {

                ViewBag.Error = "Kullanıcı Adı veya Şifreniz Hatalı";
                return View();
            }


        }
    }
}
