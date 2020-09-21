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

        // GET: WellLayers
        public ActionResult Index()
        {
            var wellLayers = db.WellLayers.Include(w => w.RockType).Include(w => w.Well);
            return View(wellLayers.ToList());
        }

        // GET: WellLayers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellLayer wellLayer = db.WellLayers.Find(id);
            if (wellLayer == null)
            {
                return HttpNotFound();
            }
            return View(wellLayer);
        }

        // GET: WellLayers/Create
        public ActionResult Create()
        {
            ViewBag.RockTypeID = new SelectList(db.RockTypes, "ID", "Name");
            ViewBag.WellID = new SelectList(db.Wells, "ID", "WellName");
            return View();
        }

        // POST: WellLayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WellID,RockTypeID,StartPoint,EndPoint")] WellLayer wellLayer)
        {
            if (ModelState.IsValid)
            {
                db.WellLayers.Add(wellLayer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RockTypeID = new SelectList(db.RockTypes, "ID", "Name", wellLayer.RockTypeID);
            ViewBag.WellID = new SelectList(db.Wells, "ID", "WellName", wellLayer.WellID);
            return View(wellLayer);
        }

        // GET: WellLayers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellLayer wellLayer = db.WellLayers.Find(id);
            if (wellLayer == null)
            {
                return HttpNotFound();
            }
            ViewBag.RockTypeID = new SelectList(db.RockTypes, "ID", "Name", wellLayer.RockTypeID);
            ViewBag.WellID = new SelectList(db.Wells, "ID", "WellName", wellLayer.WellID);
            return View(wellLayer);
        }

        // POST: WellLayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WellID,RockTypeID,StartPoint,EndPoint")] WellLayer wellLayer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellLayer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RockTypeID = new SelectList(db.RockTypes, "ID", "Name", wellLayer.RockTypeID);
            ViewBag.WellID = new SelectList(db.Wells, "ID", "WellName", wellLayer.WellID);
            return View(wellLayer);
        }

        // GET: WellLayers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellLayer wellLayer = db.WellLayers.Find(id);
            if (wellLayer == null)
            {
                return HttpNotFound();
            }
            return View(wellLayer);
        }

        // POST: WellLayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WellLayer wellLayer = db.WellLayers.Find(id);
            db.WellLayers.Remove(wellLayer);
            db.SaveChanges();
            return RedirectToAction("Index");
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
