using MulakatProje.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MulakatProje.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        DbMulakatEntities1 db = new DbMulakatEntities1();
        public ActionResult Index()
        {
            var urunler = db.Urun.ToList();
            return View(urunler);
        }
    }
}