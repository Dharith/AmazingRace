using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazingRace.Models.Models
{
    public class Race
    {
        public class Team
        {
            [Key] [Required]
            public String Name { get; set; }
            private List<Events> events = new List<Events>();
            public virtual List<Events> Events
            {
                get
                {
                    return events;
                }
                set
                {
                    events = value;
                }
            }
        }
    }

    public class Events
    {
        [Key][Required]
        [RegularExpression(@"d{4}$", ErrorMessage ="ID should be 4 digits")]
        public String EventId { get; set; }

        [Required] 
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        public String City { get; set; }

        private List<PitStop> pitStops = new List<PitStop>();
    }

    public class PitStop
    {
        [Required]
        public String Location { get; set; }

        [Required]
        public String Name { get; set; }

    }
}
    