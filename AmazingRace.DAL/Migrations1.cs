using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AmazingRace.Models.Models;

namespace AmazingRace.DAL
{
    public class Migrations1
    {
        static void Main(string[] args)
        {
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