namespace AmazingRace.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AmazingRace.Models.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AmazingRace.DAL.EventsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AmazingRace.DAL.EventsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            using (var db = new EventsContext())
            {
                db.Events.Add(new Events { EventName = "Another Blog " });
                db.SaveChanges();

                foreach (var events in db.Events)
                {
                    Console.WriteLine(events.EventName);
                }
            }
        }
    }
}
