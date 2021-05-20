using MulakatProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MulakatProje.Controllers
{
    public class TestVerisiController : Controller
    {
        Random rnd = new Random();
      
        DbMulakatEntities1 db = new DbMulakatEntities1();

        public string stringgenerator()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var stringChars = new char[8];
  
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }
            var finalString = new String(stringChars);

            return finalString;
        }
        public int intgenerator(int size)
        {
            int index = rnd.Next(size);

            return index;
        }

        public int intgenerator2(int sizesmall, int sizebig)
        {
            int index = rnd.Next(sizesmall,sizebig);

            return index;
        }

        [HttpGet]
        public ActionResult TestVerisiOlustur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            string[] Sehirler = { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };

            List<int> musteriidler = new List<int>();
            List<int> sepetidler = new List<int>();

            Musteri new_musteri = new Musteri();
            
            int sepeturuncounter = 0;

            for(int i = 0; i < musteriAdet; i++)
            {
                new_musteri.Ad = stringgenerator();
                new_musteri.Soyad = stringgenerator();
                int sehir_index = intgenerator(Sehirler.Length);
                new_musteri.Sehir = Sehirler[sehir_index];
                db.Musteri.Add(new_musteri);
                db.SaveChanges();
                musteriidler.Add(new_musteri.MusteriID);
            }

            for(int j = 0;j < sepetAdet; j++)
            {
                Sepet new_sepet = new Sepet();
                new_sepet.MusteriID = musteriidler[intgenerator(musteriidler.Count)];
                db.Sepet.Add(new_sepet);
                db.SaveChanges();
                sepeturuncounter = intgenerator2(1,6);

                for(int k = 0; k < sepeturuncounter; k++)
                {
                    SepetUrun new_sepeturun = new SepetUrun();
                    new_sepeturun.SepetID = new_sepet.SepetID;
                    new_sepeturun.Tutar = intgenerator2(100, 1001);
                    new_sepeturun.Aciklama = "Mülakat Deneme";
                    db.SepetUrun.Add(new_sepeturun);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("MainMenu","Musteri");
        }
        public ActionResult DtoSehirAnaliz()
        {

            List<Musteri> sehirler_listesi = db.Musteri
                .GroupBy(x => x.Sehir)
                .Select(x => x.FirstOrDefault())
                .ToList();
            List<Analiz> analiz = new List<Analiz>();
            List<int> sepetidler = new List<int>();

            foreach(var item in sehirler_listesi)
            {
                Analiz analiz1 = new Analiz();
                analiz1.SehirAd = item.Sehir;
                analiz1.ToplamSepet = db.Sepet.Where(x => x.Musteri.Sehir == item.Sehir).Select(x => x.SepetID).Count();
                var sepetidler2 = db.Sepet.Where(x => x.Musteri.Sehir == item.Sehir).Select(x => x.SepetID).ToList();
                foreach(var item2 in sepetidler2)
                {
                    var sepetid = db.SepetUrun.Where(x=>x.SepetID == item2).Select(x=>x.Tutar).Sum();
                    analiz1.Tutar += Convert.ToInt32(sepetid);
                }
                analiz.Add(analiz1);
            }
            

            return View(analiz);
        }
    }
}