using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger3 = db.TBL_EDUCATION.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniEgitim(TBL_EDUCATION p)
        {
            db.TBL_EDUCATION.Add(p); //tabloya ekle
            db.SaveChanges(); //değişiklikleri kaydet
            return View();
        }

        public ActionResult EgitimSil(int id)
        {
            var egitim = db.TBL_EDUCATION.Find(id);
            db.TBL_EDUCATION.Remove(egitim);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBL_EDUCATION.Find(id);
            return View("VeriGetir", veriler);
        }

        public ActionResult Guncelle (TBL_EDUCATION p)
        {
            var degerler = db.TBL_EDUCATION.Find(p.ID);
            degerler.TITLE = p.TITLE;
            degerler.SUBTITLE = p.SUBTITLE;
            degerler.DEPARTMENT = p.DEPARTMENT;
            degerler.GPA = p.GPA;

            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}