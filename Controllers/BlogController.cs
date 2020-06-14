 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string key)
        {
            var bloglar = db.Bloglar
                 .Where(i => i.Onay == true)
                .Select(i => new BlogModel()
                {
                    Anasayfa = i.Anasayfa,
                    Id = i.Id,
                    Baslik = i.Baslik,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    Onay = i.Onay,
                    Resim = i.Resim,
                    CategoryId = i.CategoryId
                });

            if (!string.IsNullOrEmpty(key))
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(key) || i.Aciklama.Contains(key));
            }

            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryId == id);
            }
            return View(bloglar.ToList());
        }

        // GET: Blog
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).ToList();
            return View(bloglar);
        }

        [AllowAnonymous]
        [HttpGet]
        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var bloglar2 = db.Bloglar.Where(i => i.CategoryId == id).FirstOrDefault();
            //var bloglar = db.Bloglar.Where(i => i.CategoryId == id).Select(i => new Blog()
            //    {
            //        Anasayfa = i.Anasayfa,
            //        Id = i.Id,
            //        Baslik = i.Baslik,
            //        Aciklama = i.Aciklama,
            //        EklenmeTarihi = i.EklenmeTarihi,
            //        Onay = i.Onay,
            //        Resim = i.Resim,
            //        CategoryId = i.CategoryId,
            //        Icerik = i.Icerik
            //    }).ToList();



            //var blog = db.Bloglar.Select().AsQueryable();
            //if (blog == null)
            //{
            //    return HttpNotFound();
            //}
            return View(bloglar2);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blog/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Aciklama,Baslik,Resim,Icerik,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.EklenmeTarihi = DateTime.Now;
             
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Aciklama,Baslik,Resim,Icerik,Onay,Anasayfa,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity!=null)
                {
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resim = blog.Resim;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.CategoryId = blog.CategoryId;

                    db.SaveChanges();
                    TempData["Blog"] = entity;
                    return RedirectToAction("Index");

                }
                
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
