using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        DbMvcCvEntities db =  new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger2 = db.TBL_EXPERIENCE.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDeneyim(TBL_EXPERIENCE p)
        {
            db.TBL_EXPERIENCE.Add(p); //tabloya ekle
            db.SaveChanges(); //değişiklikleri kaydet
            return View();
        }

        public ActionResult DeneyimSil(int id)
        {
            var deneyim = db.TBL_EXPERIENCE.Find(id);
            db.TBL_EXPERIENCE.Remove(deneyim);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}