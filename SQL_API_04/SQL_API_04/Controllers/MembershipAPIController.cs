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
    public class MembershipAPIController : ApiController
    {
        private FBLA02Entities dbA = new FBLA02Entities();
        private MembershipEntity db = new MembershipEntity();

        // GET: api/MembershipAPI
        public IQueryable<Membership> GetMemberships()
        {
            return db.Memberships;
        }

        // GET: api/MembershipAPI/5
        [ResponseType(typeof(Membership))]
        public IHttpActionResult GetMembership(int id)
        {
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            return Ok(membership);
        }

        // PUT: api/MembershipAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMembership(int id, Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != membership.ID)
            {
                return BadRequest();
            }

            db.Entry(membership).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembershipExists(id))
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

        // POST: api/MembershipAPI
        [ResponseType(typeof(Membership))]
        public IHttpActionResult PostMembership(Membership membership)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memberships.Add(membership);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = membership.ID }, membership);
        }

        // DELETE: api/MembershipAPI/5
        [ResponseType(typeof(Membership))]
        public IHttpActionResult DeleteMembership(int id)
        {
            Membership membership = db.Memberships.Find(id);
            if (membership == null)
            {
                return NotFound();
            }

            db.Memberships.Remove(membership);
            db.SaveChanges();

            return Ok(membership);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MembershipExists(int id)
        {
            return db.Memberships.Count(e => e.ID == id) > 0;
        }
    }
}