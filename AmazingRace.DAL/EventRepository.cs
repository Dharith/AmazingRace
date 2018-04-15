using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazingRace.Models;
using AmazingRace.Models.Models;

namespace AmazingRace.DAL
{
    public class EventsRespository
    {
        EventsContext db = new EventsContext();

        public IEnumerable<Events> GetEvents()
        {
            return db.Events;
        }

        public void CreateEvents(Events events)
        {
            db.Events.Add(events);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}