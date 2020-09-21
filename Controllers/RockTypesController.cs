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
    public class RockTypesController : Controller
    {
        private Session5Entities db = new Session5Entities();

        // GET: RockTypes
        public ActionResult Index()
        {
            return View(db.RockTypes.ToList());
        }

        // GET: RockTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockType rockType = db.RockTypes.Find(id);
            if (rockType == null)
            {
                return HttpNotFound();
            }
            return View(rockType);
        }

        // GET: RockTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RockTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,BackgroundColor")] RockType rockType)
        {
            if (ModelState.IsValid)
            {
                db.RockTypes.Add(rockType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rockType);
        }

        // GET: RockTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockType rockType = db.RockTypes.Find(id);
            if (rockType == null)
            {
                return HttpNotFound();
            }
            return View(rockType);
        }

        // POST: RockTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,BackgroundColor")] RockType rockType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rockType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rockType);
        }

        // GET: RockTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RockType rockType = db.RockTypes.Find(id);
            if (rockType == null)
            {
                return HttpNotFound();
            }
            return View(rockType);
        }

        // POST: RockTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RockType rockType = db.RockTypes.Find(id);
            db.RockTypes.Remove(rockType);
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
