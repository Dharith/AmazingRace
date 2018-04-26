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
        [Required]
        public int EventId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public System.DateTime StartTime { get; set; }
        public string City { get; set; }

        [Required]
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
        
        [Key]
        public string TeamName { get; set; }
        public string Photo { get; set; }
        public string EventEnrolled { get; set; }

        public List<Events> Events { get; set; }
    }
}