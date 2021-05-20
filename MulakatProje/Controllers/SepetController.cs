using MulakatProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MulakatProje.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        DbMulakatEntities1 db = new DbMulakatEntities1();
        public ActionResult Index()
        {
            Urun urunlerlist = new Urun();
            int musteriid = Convert.ToInt32(Session["MusteriID"]);
            int sepetid = db.Sepet.Where(x => x.MusteriID == musteriid).Select(x=>x.SepetID).FirstOrDefault();
            var sepet = db.SepetUrun.Where(x => x.SepetID == sepetid);
            List<Urun> urunlistesi = new List<Urun>();
            foreach(var item in sepet)
            {
               urunlistesi.Add(db.Urun.Where(x => x.UrunID == item.UrunID).FirstOrDefault());
            }
            
            
            return View(urunlistesi);
        }

        public ActionResult AddItem(int id)
        {

            int musteriid = Convert.ToInt32(Session["MusteriID"]);

            int sepetbul = db.Sepet.Where(x => x.MusteriID == musteriid).Select(x=>x.SepetID).FirstOrDefault();
            Sepet kullanicisepet = db.Sepet.Find(sepetbul);
            var urun = db.Urun.Find(id);
            if (kullanicisepet == null) { 
            Sepet sepet = new Sepet();
            sepet.MusteriID =Convert.ToInt32(Session["MusteriID"]);
            db.Sepet.Add(sepet);
            db.SaveChanges();

            SepetUrun sepeturun = new SepetUrun();
            sepeturun.SepetID = sepet.SepetID;
            sepeturun.Tutar += urun.UrunFiyat;
            sepeturun.Aciklama = "deneme";
             sepeturun.UrunID = id;
             db.SepetUrun.Add(sepeturun);
             db.SaveChanges();
             return RedirectToAction("Index", "Urunler");
            }
            else
            {
                SepetUrun sepeturun = new SepetUrun();
                sepeturun.SepetID = kullanicisepet.SepetID;
                sepeturun.Tutar = urun.UrunFiyat;
                sepeturun.Aciklama = "deneme";
                sepeturun.UrunID = id;
                db.SepetUrun.Add(sepeturun);
                db.SaveChanges();
                return RedirectToAction("Index", "Urunler");
            }

        }
    }
}