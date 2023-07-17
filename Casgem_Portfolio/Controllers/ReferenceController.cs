using Casgem_Portfolio.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Casgem_Portfolio.Controllers
{
    public class ReferenceController : Controller
    {
        // GET: Reference

        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblReference.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddReference()
        {

            return View();

        }
        [HttpPost]
        public ActionResult AddReference(TblReference r)
        {
            db.TblReference.Add(r);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteReference(int id)
        {
            var value = db.TblReference.Find(id);
            db.TblReference.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateReference(int id)
        {
            var value = db.TblReference.Find(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult UpdateReference(TblReference p)
        {
            var value = db.TblReference.Find(p.ReferenceID);
            value.ReferenceName = p.ReferenceName;
            value.ReferenceJob = p.ReferenceJob;
            value.ReferenceMail = p.ReferenceMail;
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}