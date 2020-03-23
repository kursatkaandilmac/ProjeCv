using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class KonferanslarController : Controller
    {
        DbMvcCvEntities db = new DbMvcCvEntities();
        // GET: Konferanslar
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger6 = db.TBL_AWARDS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKonferans(TBL_AWARDS p)
        {
            db.TBL_AWARDS.Add(p); //tabloya ekle
            db.SaveChanges(); //değişiklikleri kaydet
            return View();
        }

        public ActionResult KonferansSil(int id)
        {
            var konferans = db.TBL_AWARDS.Find(id);
            db.TBL_AWARDS.Remove(konferans);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}