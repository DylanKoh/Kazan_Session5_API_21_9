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

        public RockTypesController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: RockTypes
        [HttpPost]
        public ActionResult Index()
        {
            return Json(db.RockTypes.ToList());
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
