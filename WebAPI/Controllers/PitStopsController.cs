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
using AmazingRace.Context;
using AmazingRace.Models;

namespace AmazingRace.Controllers
{
    public class PitStopsController : ApiController
    {
        private EventContext db = new EventContext();

        // GET: api/PitStops
        public IQueryable<PitStop> GetPitStops()
        {
            return db.PitStops;
        }

        // GET: api/PitStops/5
        [ResponseType(typeof(PitStop))]
        public IHttpActionResult GetPitStop(string id)
        {
            PitStop pitStop = db.PitStops.Find(id);
            if (pitStop == null)
            {
                return NotFound();
            }

            return Ok(pitStop);
        }

        // PUT: api/PitStops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPitStop(string id, PitStop pitStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pitStop.Name)
            {
                return BadRequest();
            }

            db.Entry(pitStop).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitStopExists(id))
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

        // POST: api/PitStops
        [ResponseType(typeof(PitStop))]
        public IHttpActionResult PostPitStop(PitStop pitStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PitStops.Add(pitStop);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PitStopExists(pitStop.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pitStop.Name }, pitStop);
        }

        // DELETE: api/PitStops/5
        [ResponseType(typeof(PitStop))]
        public IHttpActionResult DeletePitStop(string id)
        {
            PitStop pitStop = db.PitStops.Find(id);
            if (pitStop == null)
            {
                return NotFound();
            }

            db.PitStops.Remove(pitStop);
            db.SaveChanges();

            return Ok(pitStop);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PitStopExists(string id)
        {
            return db.PitStops.Count(e => e.Name == id) > 0;
        }
    }
}