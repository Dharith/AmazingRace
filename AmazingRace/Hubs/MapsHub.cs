using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace AmazingRace.Hubs
{
    public class MapsHub : Hub
    {
        public IEnumerable<Location> GetLocations()
        {
            return FileWatcher.Data;
        }
    }
}