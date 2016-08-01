﻿using System;
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
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.CustomerModels.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.CustomerModels.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,street,city,state,zip,email,UserID,rating,status,registrationDate")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                db.CustomerModels.Add(customerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerModels);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.CustomerModels.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,street,city,state,zip,email,UserID,rating,status,registrationDate")] CustomerModels customerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerModels);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerModels customerModels = db.CustomerModels.Find(id);
            if (customerModels == null)
            {
                return HttpNotFound();
            }
            return View(customerModels);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerModels customerModels = db.CustomerModels.Find(id);
            db.CustomerModels.Remove(customerModels);
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
