using MulakatProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MulakatProje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DbMulakatEntities1 db = new DbMulakatEntities1();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Musteri p)
        {
            var musteri = db.Musteri.FirstOrDefault(x => x.KullaniciAdı == p.KullaniciAdı && x.Sifre == p.Sifre);
            if(musteri != null)
            {
                Session["Ad"] = musteri.Ad.ToString();
                Session["Soyad"] = musteri.Soyad.ToString();
                Session["KullaniciAdı"] = musteri.KullaniciAdı.ToString();
                Session["Sehir"] = musteri.Sehir.ToString();
                Session["MusteriID"] = musteri.MusteriID;
                return RedirectToAction("MainMenu","Musteri");
            }
            else
            {
                ViewBag.Error = "Hatalı kullanıcı Adı veya Şifre";
                return View("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Musteri p)
        {
            db.Musteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}