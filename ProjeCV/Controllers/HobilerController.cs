using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class HobilerController : Controller
    {
        DbMvcCvEntities db = new DbMvcCvEntities();
        // GET: Hobiler
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger5 = db.TBL_INTERESTS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniHobi(TBL_INTERESTS p)
        {
            db.TBL_INTERESTS.Add(p); //tabloya ekle
            db.SaveChanges(); //değişiklikleri kaydet
            return View();
        }

        public ActionResult HobiSil(int id)
        {
            var hobi = db.TBL_INTERESTS.Find(id);
            db.TBL_INTERESTS.Remove(hobi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBL_INTERESTS.Find(id);
            return View("VeriGetir", veriler);
        }

        public ActionResult Guncelle(TBL_INTERESTS p)
        {
            var degerler = db.TBL_INTERESTS.Find(p.ID);
            degerler.INTEREST = p.INTEREST;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}