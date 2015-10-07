using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeerShelf.Data;
using BeerShelf.Model;

namespace BeerShelf.Web.Controllers
{
    public class BottlesController : Controller
    {
        private BeerShelfDbContext db = new BeerShelfDbContext();

        // GET: Bottles
        public ActionResult Index()
        {
            return View(db.Bottles.ToList());
        }

        // GET: Bottles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // GET: Bottles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bottles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Alcohol,Name,Country,Brand")] Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Bottles.Add(bottle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bottle);
        }

        // GET: Bottles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // POST: Bottles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Alcohol,Name,Country,Brand")] Bottle bottle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottle);
        }

        // GET: Bottles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottle bottle = db.Bottles.Find(id);
            if (bottle == null)
            {
                return HttpNotFound();
            }
            return View(bottle);
        }

        // POST: Bottles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottle bottle = db.Bottles.Find(id);
            db.Bottles.Remove(bottle);
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
