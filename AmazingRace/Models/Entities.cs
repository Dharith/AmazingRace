using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Required]
        public int PitStopId { get; set; }

        [Required]
        public String EventName { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class Teams
    {
        
        [Key]
        [Required]
        public string TeamName { get; set; }
        public string Photo { get; set; }
        public string EventEnrolled { get; set; }

        [Required]
        [Display(Name = "Event")]
        public string SelectedEvent { get; set; }
        public IEnumerable<SelectListItem> EventsList { get; set; }
    }
   }