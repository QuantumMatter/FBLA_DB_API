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
    public class defaultSubGroupAPIController : ApiController
    {
        private RealSub01 db = new RealSub01();

        // GET: api/defaultSubGroupAPI
        public IQueryable<defaultSubGroup> GetdefaultSubGroups()
        {
            return db.defaultSubGroups;
        }

        // GET: api/defaultSubGroupAPI/5
        [ResponseType(typeof(defaultSubGroup))]
        public IHttpActionResult GetdefaultSubGroup(int id)
        {
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            if (defaultSubGroup == null)
            {
                return NotFound();
            }

            return Ok(defaultSubGroup);
        }

        // PUT: api/defaultSubGroupAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutdefaultSubGroup(int id, defaultSubGroup defaultSubGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != defaultSubGroup.ID)
            {
                return BadRequest();
            }

            db.Entry(defaultSubGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!defaultSubGroupExists(id))
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

        // POST: api/defaultSubGroupAPI
        [ResponseType(typeof(defaultSubGroup))]
        public IHttpActionResult PostdefaultSubGroup(defaultSubGroup defaultSubGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.defaultSubGroups.Add(defaultSubGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = defaultSubGroup.ID }, defaultSubGroup);
        }

        // DELETE: api/defaultSubGroupAPI/5
        [ResponseType(typeof(defaultSubGroup))]
        public IHttpActionResult DeletedefaultSubGroup(int id)
        {
            defaultSubGroup defaultSubGroup = db.defaultSubGroups.Find(id);
            if (defaultSubGroup == null)
            {
                return NotFound();
            }

            db.defaultSubGroups.Remove(defaultSubGroup);
            db.SaveChanges();

            return Ok(defaultSubGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool defaultSubGroupExists(int id)
        {
            return db.defaultSubGroups.Count(e => e.ID == id) > 0;
        }
    }
}