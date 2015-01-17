using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SQL_API_04.Models;

namespace SQL_API_04.Controllers
{
    public class subGroupAPIController : ApiController
    {
        private RealSub01 db = new RealSub01();

        // GET: api/subGroupAPI
        public IQueryable<subGroup> GetsubGroups()
        {
            return db.subGroups;
        }

        // GET: api/subGroupAPI/5
        [ResponseType(typeof(subGroup))]
        public IHttpActionResult GetsubGroup(int id)
        {
            subGroup subGroup = db.subGroups.Find(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            return Ok(subGroup);
        }

        // PUT: api/subGroupAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsubGroup(int id, subGroup subGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subGroup.ID)
            {
                return BadRequest();
            }

            db.Entry(subGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subGroupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/subGroupAPI
        [ResponseType(typeof(subGroup))]
        public IHttpActionResult PostsubGroup(subGroup subGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subGroups.Add(subGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subGroup.ID }, subGroup);
        }

        // DELETE: api/subGroupAPI/5
        [ResponseType(typeof(subGroup))]
        public IHttpActionResult DeletesubGroup(int id)
        {
            subGroup subGroup = db.subGroups.Find(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            db.subGroups.Remove(subGroup);
            db.SaveChanges();

            return Ok(subGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subGroupExists(int id)
        {
            return db.subGroups.Count(e => e.ID == id) > 0;
        }
    }
}