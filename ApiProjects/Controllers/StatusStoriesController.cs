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
    public class StatusStoriesController : ApiController
    {
        private db_projectsEntities1 db = new db_projectsEntities1();

        // GET: api/StatusStories
        public IQueryable<StatusStory> GetStatusStories()
        {
            return db.StatusStories;
        }

        // GET: api/StatusStories/5
        [ResponseType(typeof(StatusStory))]
        public IHttpActionResult GetStatusStory(int id)
        {
            StatusStory statusStory = db.StatusStories.Find(id);
            if (statusStory == null)
            {
                return NotFound();
            }

            return Ok(statusStory);
        }

        // PUT: api/StatusStories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusStory(int id, StatusStory statusStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusStory.IdStatusStory)
            {
                return BadRequest();
            }

            db.Entry(statusStory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusStoryExists(id))
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

        // POST: api/StatusStories
        [ResponseType(typeof(StatusStory))]
        public IHttpActionResult PostStatusStory(StatusStory statusStory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusStories.Add(statusStory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusStory.IdStatusStory }, statusStory);
        }

        // DELETE: api/StatusStories/5
        [ResponseType(typeof(StatusStory))]
        public IHttpActionResult DeleteStatusStory(int id)
        {
            StatusStory statusStory = db.StatusStories.Find(id);
            if (statusStory == null)
            {
                return NotFound();
            }

            db.StatusStories.Remove(statusStory);
            db.SaveChanges();

            return Ok(statusStory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusStoryExists(int id)
        {
            return db.StatusStories.Count(e => e.IdStatusStory == id) > 0;
        }
    }
}