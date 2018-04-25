using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazingRace.Models
{
    public class Entities
    {
    }
    public class Events
    {
        [Key]
        public int EventId { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime StartTime { get; set; }
        public string City { get; set; }
        public string EventName { get; set; }

        public List<PitStops> PitStops;
    }
    public class PitStops
    {
        [Key]
        public int PitStopId { get; set; }

        public String EventName { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class Teams
    {

        public int TeamId { get; set; }

        [Key]
        public string TeamName { get; set; }
        public string Photo { get; set; }
        public string EventEnrolled { get; set; }

        public List<Events> Events { get; set; }
    }
}