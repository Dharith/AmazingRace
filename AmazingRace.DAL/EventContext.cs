using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AmazingRace.Models;
using AmazingRace.Models.Models;

namespace AmazingRace.DAL
{
    public class EventsContext : DbContext
    {
        public EventsContext() : base()
        {
        }

        public DbSet<Events> Events { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}