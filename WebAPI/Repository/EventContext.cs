using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AmazingRace.Models;

namespace AmazingRace.Context
{
    public class EventContext:DbContext
    {
        public EventContext() : base("DbConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<PitStop> PitStops { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}