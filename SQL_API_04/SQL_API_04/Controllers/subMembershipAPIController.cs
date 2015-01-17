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
    public class subMembershipAPIController : ApiController
    {
        private RealSub01 db = new RealSub01();

        // GET: api/subMembershipAPI
        public IQueryable<subMembership> GetsubMemberships()
        {
            return db.subMemberships;
        }

        // GET: api/subMembershipAPI/5
        [ResponseType(typeof(subMembership))]
        public IHttpActionResult GetsubMembership(int id)
        {
            subMembership subMembership = db.subMemberships.Find(id);
            if (subMembership == null)
            {
                return NotFound();
            }

            return Ok(subMembership);
        }

        // PUT: api/subMembershipAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsubMembership(int id, subMembership subMembership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subMembership.ID)
            {
                return BadRequest();
            }

            db.Entry(subMembership).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subMembershipExists(id))
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

        // POST: api/subMembershipAPI
        [ResponseType(typeof(subMembership))]
        public IHttpActionResult PostsubMembership(subMembership subMembership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subMemberships.Add(subMembership);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subMembership.ID }, subMembership);
        }

        // DELETE: api/subMembershipAPI/5
        [ResponseType(typeof(subMembership))]
        public IHttpActionResult DeletesubMembership(int id)
        {
            subMembership subMembership = db.subMemberships.Find(id);
            if (subMembership == null)
            {
                return NotFound();
            }

            db.subMemberships.Remove(subMembership);
            db.SaveChanges();

            return Ok(subMembership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subMembershipExists(int id)
        {
            return db.subMemberships.Count(e => e.ID == id) > 0;
        }
    }
}