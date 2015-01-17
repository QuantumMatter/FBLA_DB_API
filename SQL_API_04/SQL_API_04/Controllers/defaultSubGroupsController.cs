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
    public class defaultSubGroupsController : Controller
    {
        private RealSub01 db = new RealSub01();

        // GET: defaultSubGroups
        public ActionResult Index()
        {
            return View(db.defaultSubGroups.ToList());
        }

        // GET: defaultSubGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            if (defaultSubGroup == null)
            {
                return HttpNotFound();
            }
            return View(defaultSubGroup);
        }

        // GET: defaultSubGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: defaultSubGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,groupID,subGroupID")] defaultSubGroup defaultSubGroup)
        {
            if (ModelState.IsValid)
            {
                db.defaultSubGroups.Add(defaultSubGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(defaultSubGroup);
        }

        // GET: defaultSubGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            if (defaultSubGroup == null)
            {
                return HttpNotFound();
            }
            return View(defaultSubGroup);
        }

        // POST: defaultSubGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,groupID,subGroupID")] defaultSubGroup defaultSubGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(defaultSubGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(defaultSubGroup);
        }

        // GET: defaultSubGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            if (defaultSubGroup == null)
            {
                return HttpNotFound();
            }
            return View(defaultSubGroup);
        }

        // POST: defaultSubGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            db.defaultSubGroups.Remove(defaultSubGroup);
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
