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
    public class ConnectionAPIController : ApiController
    {
        private PostsConnectionsEntities db = new PostsConnectionsEntities();

        // GET: api/ConnectionAPI
        public IQueryable<Connection> GetConnections()
        {
            return db.Connections;
        }

        // GET: api/ConnectionAPI/5
        [ResponseType(typeof(Connection))]
        public IHttpActionResult GetConnection(int id)
        {
            Connection connection = db.Connections.Find(id);
            if (connection == null)
            {
                return NotFound();
            }

            return Ok(connection);
        }

        // PUT: api/ConnectionAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConnection(int id, Connection connection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != connection.ID)
            {
                return BadRequest();
            }

            db.Entry(connection).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(id))
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

        // POST: api/ConnectionAPI
        [ResponseType(typeof(Connection))]
        public IHttpActionResult PostConnection(Connection connection)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Connections.Add(connection);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = connection.ID }, connection);
        }

        // DELETE: api/ConnectionAPI/5
        [ResponseType(typeof(Connection))]
        public IHttpActionResult DeleteConnection(int id)
        {
            Connection connection = db.Connections.Find(id);
            if (connection == null)
            {
                return NotFound();
            }

            db.Connections.Remove(connection);
            db.SaveChanges();

            return Ok(connection);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConnectionExists(int id)
        {
            return db.Connections.Count(e => e.ID == id) > 0;
        }
    }
}