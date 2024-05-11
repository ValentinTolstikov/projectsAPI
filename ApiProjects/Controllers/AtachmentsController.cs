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
using ApiProjects.Models;

namespace ApiProjects.Controllers
{
    public class AtachmentsController : ApiController
    {
        private db_projectsEntities1 db = new db_projectsEntities1();

        // GET: api/Atachments
        public IQueryable<Atachment> GetAtachments()
        {
            return db.Atachments;
        }

        // GET: api/Atachments/5
        [ResponseType(typeof(Atachment))]
        public IHttpActionResult GetAtachment(int id)
        {
            Atachment atachment = db.Atachments.Find(id);
            if (atachment == null)
            {
                return NotFound();
            }

            return Ok(atachment);
        }

        // PUT: api/Atachments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAtachment(int id, Atachment atachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atachment.IdAtachment)
            {
                return BadRequest();
            }

            db.Entry(atachment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtachmentExists(id))
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

        // POST: api/Atachments
        [ResponseType(typeof(Atachment))]
        public IHttpActionResult PostAtachment(Atachment atachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atachments.Add(atachment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = atachment.IdAtachment }, atachment);
        }

        // DELETE: api/Atachments/5
        [ResponseType(typeof(Atachment))]
        public IHttpActionResult DeleteAtachment(int id)
        {
            Atachment atachment = db.Atachments.Find(id);
            if (atachment == null)
            {
                return NotFound();
            }

            db.Atachments.Remove(atachment);
            db.SaveChanges();

            return Ok(atachment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtachmentExists(int id)
        {
            return db.Atachments.Count(e => e.IdAtachment == id) > 0;
        }
    }
}