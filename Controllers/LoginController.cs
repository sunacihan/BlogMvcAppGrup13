using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogMvcApp.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        private BlogContext db = new BlogContext();
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginUser(String inputPassword, string inputEmail)
        {
            var girisOnayi = false;
            //LINQ Sorugusu
            var kullanici = db.Girisler.Where(i => i.Email == inputEmail && i.Sifre == inputPassword).FirstOrDefault();
            if (kullanici != null)
            {
                //Kullanıcı giriş bilgilerini doğru girerse 
                //bir FormsAuthentication SetAuthCookie methodu kullanılarak bir session cookie oluşturulur.
                //birinci parametre kullanıcı adını gösterir, ikinci parametre ise Beni Hatırla kısmı ile ilgilidir. False olarak bıraktık.
                girisOnayi = true;
                FormsAuthentication.SetAuthCookie(kullanici.Isim, false);
                return RedirectToAction("Index","Home");
            }

            //return RedirectToAction("LoginUser");

            return Json(girisOnayi);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}