using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI.Context;
using WebAPI.Interface;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [System.Web.Http.RoutePrefix("api/Events")]
    public class EventsController : ApiController
    {
        private EventContext db = new EventContext();
        private IRepository<Event> _eventRepository = null;
        public EventsController()
        {
            this._eventRepository = new EventRepository<Event>();
        } 

        [Route("AllEvents")]
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
                IEnumerable<Event> events = _eventRepository.GetAll();
                return events;
        }

        // GET: api/EventsAPI/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(string id)
        {
            Event @event = new Event(); ;
            if (id != null)
            {
                @event = db.Events.Find(id);
            }
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/EventsAPI/5
        [Route("InsertEvent")]
        [HttpPost]
        public void PutEvent(Event @event)
        {
            try
            {
                this._eventRepository.Insert(@event);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            
        }

        // POST: api/CreateEvent
        [ResponseType(typeof(Event))]
        [Route("CreateEvent")]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EventExists(@event.EventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = @event.EventId }, @event);
        }

        // DELETE: api/EventsAPI/5
        [Route("DeleteEvent")]
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(string id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(string id)
        {
            return db.Events.Count(e => e.EventId == id) > 0;
        }
    }
}