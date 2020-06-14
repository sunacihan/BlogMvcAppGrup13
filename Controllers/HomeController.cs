using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private BlogContext context = new BlogContext();
        // GET: Home
      
        public ActionResult Index()
        {
            var bloglar = context.Bloglar
                 .Where(i => i.Onay == true && i.Anasayfa == true)
                .Select(i => new BlogModel()
                {
                    Anasayfa = i.Anasayfa,
                    Id = i.Id,
                    Baslik = i.Baslik,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Onay = i.Onay,
                    Resim = i.Resim
                });
               
            
            
            return View(bloglar.ToList());
        }

        [AllowAnonymous]
        public ActionResult Giris()
        {
            var bloglar = context.Bloglar
                .Where(i => i.Onay == true && i.Anasayfa == true)
               .Select(i => new BlogModel()
               {
                   Anasayfa = i.Anasayfa,
                   Id = i.Id,
                   Baslik = i.Baslik,
                   Aciklama = i.Aciklama,
                   EklenmeTarihi = i.EklenmeTarihi,
                   Onay = i.Onay,
                   Resim = i.Resim
               });



            return View(bloglar.ToList());
            
        }
    }
}