using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbMvcCvEntities db = new DbMvcCvEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBL_ABOUT.ToList();
            cs.Deger2 = db.TBL_EXPERIENCE.ToList();
            cs.Deger3 = db.TBL_EDUCATION.ToList();
            cs.Deger4 = db.TBL_SKILLS.ToList();
            cs.Deger5 = db.TBL_INTERESTS.ToList();
            cs.Deger6 = db.TBL_AWARDS.ToList();

            return View(cs);
            //var degerler = db.TBL_ABOUT.ToList();
            //return View(degerler);
        }
    }
}