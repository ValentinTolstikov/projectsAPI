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
    public class InpectorsController : ApiController
    {
        private db_projectsEntities1 db = new db_projectsEntities1();

        // GET: api/Inpectors
        public IQueryable<Inpector> GetInpectors()
        {
            return db.Inpectors;
        }

        // GET: api/Inpectors/5
        [ResponseType(typeof(Inpector))]
        public IHttpActionResult GetInpector(int id)
        {
            Inpector inpector = db.Inpectors.Find(id);
            if (inpector == null)
            {
                return NotFound();
            }

            return Ok(inpector);
        }

        // PUT: api/Inpectors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInpector(int id, Inpector inpector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inpector.IdInspector)
            {
                return BadRequest();
            }

            db.Entry(inpector).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InpectorExists(id))
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

        // POST: api/Inpectors
        [ResponseType(typeof(Inpector))]
        public IHttpActionResult PostInpector(Inpector inpector)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Inpectors.Add(inpector);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inpector.IdInspector }, inpector);
        }

        // DELETE: api/Inpectors/5
        [ResponseType(typeof(Inpector))]
        public IHttpActionResult DeleteInpector(int id)
        {
            Inpector inpector = db.Inpectors.Find(id);
            if (inpector == null)
            {
                return NotFound();
            }

            db.Inpectors.Remove(inpector);
            db.SaveChanges();

            return Ok(inpector);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InpectorExists(int id)
        {
            return db.Inpectors.Count(e => e.IdInspector == id) > 0;
        }
    }
}