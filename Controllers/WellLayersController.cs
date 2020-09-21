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
    public class WellLayersController : Controller
    {
        private Session5Entities db = new Session5Entities();

        public WellLayersController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: WellLayers
        [HttpPost]
        public ActionResult Index()
        {
            var wellLayers = db.WellLayers;
            return Json(wellLayers.ToList());
        }

        // POST: WellLayers/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,WellID,RockTypeID,StartPoint,EndPoint")] WellLayer wellLayer)
        {
            if (ModelState.IsValid)
            {
                db.WellLayers.Add(wellLayer);
                db.SaveChanges();
                return Json("Create well layer!");
            }
            return Json(wellLayer);
        }

        // POST: WellLayers/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,WellID,RockTypeID,StartPoint,EndPoint")] WellLayer wellLayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellLayer).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Successfully edited well layer!");
            }
            return View(wellLayer);
        }

        // POST: WellLayers/GetWellLayers?WellID={}
        [HttpPost]
        public ActionResult GetWellLayers(long WellID)
        {
            var getWellLayer = (from x in db.WellLayers
                                where x.WellID == WellID
                                join y in db.RockTypes on x.RockTypeID equals y.ID
                                orderby x.StartPoint
                                select new { RockName = y.Name, BackgroundColour = y.BackgroundColor, Start = x.StartPoint, End = x.EndPoint }).ToList();
            return Json(getWellLayer);
        }

        // POST: WellLayers/GetOriginalWellLayers?WellID={}
        [HttpPost]
        public ActionResult GetOriginalWellLayers(long WellID)
        {
            var getWellLayer = (from x in db.WellLayers
                                where x.WellID == WellID
                                select x).ToList();
            return Json(getWellLayer);
        }

        // POST: WellLayers/Delete
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed([Bind(Include = "ID,WellID,RockTypeID,StartPoint,EndPoint")] WellLayer wellLayer)
        {
            var findToDelete = (from x in db.WellLayers
                                where x.WellID == wellLayer.WellID && x.RockTypeID == wellLayer.RockTypeID
                                select x).FirstOrDefault();
            if (findToDelete != null)
            {
                db.WellLayers.Remove(findToDelete);
                db.SaveChanges();
            }
            return Json("Well Layer removed!");
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
