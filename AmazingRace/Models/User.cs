using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazingRace.Models
{
    public class User
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string passWord { get; set; }
    }
}