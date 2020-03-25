using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
using PagedList;
using PagedList.Mvc;

namespace ProjeCV.Controllers
{
    public class KonferanslarController : Controller
    {
        DbMvcCvEntities db = new DbMvcCvEntities();
        // GET: Konferanslar
        public ActionResult Index(int sayfa = 1)
        {
            //Class1 cs = new Class1();
            var degerler = db.TBL_AWARDS.ToList().ToPagedList(sayfa,5);
            return View(degerler);
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

        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBL_AWARDS.Find(id);
            return View("VeriGetir", veriler);
        }

        public ActionResult Guncelle(TBL_AWARDS p)
        {
            var degerler = db.TBL_AWARDS.Find(p.ID);
            degerler.AWARD = p.AWARD;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}