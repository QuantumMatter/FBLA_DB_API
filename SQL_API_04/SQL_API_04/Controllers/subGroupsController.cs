using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SQL_API_04.Models;

namespace SQL_API_04.Controllers
{
    public class subGroupsController : Controller
    {
        private RealSub01 db = new RealSub01();

        // GET: subGroups
        public ActionResult Index()
        {
            return View(db.subGroups.ToList());
        }

        // GET: subGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subGroup subGroup = db.subGroups.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // GET: subGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,parentGroupID,pic,Name")] subGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                db.subGroups.Add(subGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subGroup);
        }

        // GET: subGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subGroup subGroup = db.subGroups.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // POST: subGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,parentGroupID,pic,Name")] subGroup subGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subGroup);
        }

        // GET: subGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subGroup subGroup = db.subGroups.Find(id);
            if (subGroup == null)
            {
                return HttpNotFound();
            }
            return View(subGroup);
        }

        // POST: subGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subGroup subGroup = db.subGroups.Find(id);
            db.subGroups.Remove(subGroup);
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
