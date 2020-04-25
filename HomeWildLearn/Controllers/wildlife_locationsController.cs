﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeWildLearn.Models;

namespace HomeWildLearn.Controllers
{
    public class wildlife_locationsController : Controller
    {
        private WildlifeLocationModel db = new WildlifeLocationModel();
        //to access Animal namde from animal model
        private AnimalModel adb = new AnimalModel();
        // GET: wildlife_locations
        public ActionResult Index()
        {
           
            return View(db.wildlife_locations.ToList());
        }

        // GET: wildlife_locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_locations wildlife_locations = db.wildlife_locations.Find(id);
            if (wildlife_locations == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_locations);
        }

        // GET: wildlife_locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wildlife_locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location_id,Animal_id,Class,Latitude,Longitude")] wildlife_locations wildlife_locations)
        {
            if (ModelState.IsValid)
            {
                db.wildlife_locations.Add(wildlife_locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wildlife_locations);
        }

        // GET: wildlife_locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_locations wildlife_locations = db.wildlife_locations.Find(id);
            if (wildlife_locations == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_locations);
        }

        // POST: wildlife_locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Location_id,Animal_id,Class,Latitude,Longitude")] wildlife_locations wildlife_locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wildlife_locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wildlife_locations);
        }

        // GET: wildlife_locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wildlife_locations wildlife_locations = db.wildlife_locations.Find(id);
            if (wildlife_locations == null)
            {
                return HttpNotFound();
            }
            return View(wildlife_locations);
        }

        // POST: wildlife_locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            wildlife_locations wildlife_locations = db.wildlife_locations.Find(id);
            db.wildlife_locations.Remove(wildlife_locations);
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
