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

        // GET: Wells
        public ActionResult Index()
        {
            var wells = db.Wells.Include(w => w.WellType);
            return View(wells.ToList());
        }

        // GET: Wells/Details/5
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
            return View(well);
        }

        // GET: Wells/Create
        public ActionResult Create()
        {
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name");
            return View();
        }

        // POST: Wells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Wells.Add(well);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // GET: Wells/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // POST: Wells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,WellTypeID,WellName,GasOilDepth,Capacity")] Well well)
        {
            if (ModelState.IsValid)
            {
                db.Entry(well).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WellTypeID = new SelectList(db.WellTypes, "ID", "Name", well.WellTypeID);
            return View(well);
        }

        // GET: Wells/Delete/5
        public ActionResult Delete(long? id)
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
            return View(well);
        }

        // POST: Wells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Well well = db.Wells.Find(id);
            db.Wells.Remove(well);
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
