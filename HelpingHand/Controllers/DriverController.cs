using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpingHand.Models;

namespace HelpingHand.Controllers
{
    public class DriverController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Driver
        public ActionResult Index()
        {
            return View(db.DriverModels.ToList());
        }

        // GET: Driver/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModels driverModels = db.DriverModels.Find(id);
            if (driverModels == null)
            {
                return HttpNotFound();
            }
            return View(driverModels);
        }

        // GET: Driver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,email,UserID,geoTag,rating,status,rangePreference,registrationDate")] DriverModels driverModels)
        {
            if (ModelState.IsValid)
            {
                db.DriverModels.Add(driverModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverModels);
        }

        // GET: Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModels driverModels = db.DriverModels.Find(id);
            if (driverModels == null)
            {
                return HttpNotFound();
            }
            return View(driverModels);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,street,city,state,zip,email,driverslicense,UserID,geoTag,rating,status,rangePreference,registrationDate")] DriverModels driverModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(driverModels);
        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverModels driverModels = db.DriverModels.Find(id);
            if (driverModels == null)
            {
                return HttpNotFound();
            }
            return View(driverModels);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverModels driverModels = db.DriverModels.Find(id);
            ApplicationUser driverLog = db.Users.Where(x => x.Id == driverModels.UserID).SingleOrDefault();
            db.DriverModels.Remove(driverModels);
            db.Users.Remove(driverLog);
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
