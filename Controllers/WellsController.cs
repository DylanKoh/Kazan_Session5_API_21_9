using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kazan_Session5_API_21_9;

namespace Kazan_Session5_API_21_9.Controllers
{
    public class WellsController : Controller
    {
        private Session5Entities db = new Session5Entities();

        public WellsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: Wells
        [HttpPost]
        public ActionResult Index()
        {
            var wells = db.Wells;
            return Json(wells.ToList());
        }

        // POST: Wells/Details/5
        [HttpPost]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Well well = db.Wells.Find(id);
            if (well == null)
            {
                return HttpNotFound();
            }
            return Json(well);
        }

        // POST: Wells/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                var findWell = (from x in db.Wells
                                where x.WellName == well.WellName
                                select x).FirstOrDefault();
                if (findWell == null)
                {
                    db.Wells.Add(well);
                    db.SaveChanges();
                    return Json("Created Well conpleted!");
                }
                else
                {
                    return Json(well);
                }
                
            }
            return Json(well);
        }

        // POST: Wells/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                var findWell = (from x in db.Wells
                                where x.WellName == well.WellName &&  x.ID != well.ID
                                select x).FirstOrDefault();
                if (findWell == null)
                {
                    db.Entry(well).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("Completed editing well!");
                }
                else
                {
                    return Json(well);
                }

            }
            return Json(well);
        }

        // POST: Wells/GetNewID
        [HttpPost]
        public ActionResult GetNewID()
        {
            var getNew = (from x in db.Wells
                          orderby x.ID descending
                          select x.ID).FirstOrDefault() + 1;
            return Json(getNew);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
