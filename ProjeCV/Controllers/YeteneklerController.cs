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
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index(int sayfa = 1)
        {
            //Class1 cs = new Class1();
            var degerler = db.TBL_SKILLS.ToList().ToPagedList(sayfa,5); //her sayfada kaç tane olacağı
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TBL_SKILLS p)
        {
            db.TBL_SKILLS.Add(p); //tabloya ekle
            db.SaveChanges(); //değişiklikleri kaydet
            return View();
        }

        public ActionResult YetenekSil(int id)
        {
            var yetenek = db.TBL_SKILLS.Find(id);
            db.TBL_SKILLS.Remove(yetenek);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBL_SKILLS.Find(id);
            return View("VeriGetir", veriler);
        }

        public ActionResult Guncelle(TBL_SKILLS p)
        {
            var degerler = db.TBL_SKILLS.Find(p.ID);
            degerler.SKILL = p.SKILL;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}