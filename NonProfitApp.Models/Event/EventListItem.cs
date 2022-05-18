using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonProfitApp.Models.Event
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public string NonProfitName { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string EventAddress { get; set; }

    }
}