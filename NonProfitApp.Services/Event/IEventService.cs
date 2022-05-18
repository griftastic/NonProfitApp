using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitApp.Models.Event;

namespace NonProfitApp.Services.Event
{
    public interface IEventService
    {
        Task<bool> CreateEventAsync(EventCreate request);
        Task<IEnumerable<EventListItem>> GetAllEventsAsync();
        Task<EventDetail> GetEventByIdAsync(int noteId);
    }
}