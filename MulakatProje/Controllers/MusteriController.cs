using MulakatProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MulakatProje.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMulakatEntities1 db = new DbMulakatEntities1();
        public ActionResult MainMenu()
        {
            return View();
        }

        public ActionResult Index()
        {
            int musteriid = Convert.ToInt32(Session["MusteriID"]);
            var musteri = db.Musteri.Find(musteriid);
            return View(musteri);
        }
    }
}