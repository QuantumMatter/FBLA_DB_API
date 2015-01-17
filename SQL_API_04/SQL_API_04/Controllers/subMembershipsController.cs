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
    public class subMembershipsController : Controller
    {
        private RealSub01 db = new RealSub01();

        // GET: subMemberships
        public ActionResult Index()
        {
            return View(db.subMemberships.ToList());
        }

        // GET: subMemberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subMembership subMembership = db.subMemberships.Find(id);
            if (subMembership == null)
            {
                return HttpNotFound();
            }
            return View(subMembership);
        }

        // GET: subMemberships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subMemberships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,subGroupID,Role")] subMembership subMembership)
        {
            if (ModelState.IsValid)
            {
                db.subMemberships.Add(subMembership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subMembership);
        }

        // GET: subMemberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subMembership subMembership = db.subMemberships.Find(id);
            if (subMembership == null)
            {
                return HttpNotFound();
            }
            return View(subMembership);
        }

        // POST: subMemberships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,subGroupID,Role")] subMembership subMembership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subMembership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subMembership);
        }

        // GET: subMemberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subMembership subMembership = db.subMemberships.Find(id);
            if (subMembership == null)
            {
                return HttpNotFound();
            }
            return View(subMembership);
        }

        // POST: subMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subMembership subMembership = db.subMemberships.Find(id);
            db.subMemberships.Remove(subMembership);
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
