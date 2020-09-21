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
    public class WellTypesController : Controller
    {
        private Session5Entities db = new Session5Entities();

        // GET: WellTypes
        public ActionResult Index()
        {
            return View(db.WellTypes.ToList());
        }

        // GET: WellTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellType wellType = db.WellTypes.Find(id);
            if (wellType == null)
            {
                return HttpNotFound();
            }
            return View(wellType);
        }

        // GET: WellTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WellTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] WellType wellType)
        {
            if (ModelState.IsValid)
            {
                db.WellTypes.Add(wellType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wellType);
        }

        // GET: WellTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellType wellType = db.WellTypes.Find(id);
            if (wellType == null)
            {
                return HttpNotFound();
            }
            return View(wellType);
        }

        // POST: WellTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] WellType wellType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wellType);
        }

        // GET: WellTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WellType wellType = db.WellTypes.Find(id);
            if (wellType == null)
            {
                return HttpNotFound();
            }
            return View(wellType);
        }

        // POST: WellTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            WellType wellType = db.WellTypes.Find(id);
            db.WellTypes.Remove(wellType);
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
