using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NonProfitApp.Data;
using NonProfitApp.Data.Entities;
using NonProfitApp.Models.Event;

namespace NonProfitApp.Services.Event
{
    public class EventService : IEventService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public EventService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);

            if (!validId)
                throw new Exception("Attempted to build EventService without User Id claim.");

                _dbContext = dbContext;
        }
        public async Task<bool> CreateEventAsync(EventCreate request)
        {
            var eventEntity = new EventEntity
            {
                // NonProfitName = request.NonProfitName,
                EventName = request.EventName,
                EventDescription = request.EventDescription,
                EventDate = request.EventDate,
                EventAddress = request.EventAddress,
                UserId = _userId
            };

            _dbContext.Events.Add(eventEntity);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<EventListItem>> GetAllEventsAsync()
        {
            var events = await _dbContext.Events
                .Where(entity => entity.UserId == _userId)
                .Select(entity => new EventListItem
                {
                    EventId = entity.EventId,
                    // NonProfitName = entity.NonProfitName,
                    EventName = entity.EventName,
                    EventDescription = entity.EventDescription,
                    EventDate = entity.EventDate,
                    EventAddress = entity.EventAddress
                })
                .ToListAsync();

            return events;
        }

    public async Task<EventDetail> GetEventByIdAsync(int eventId)
    {
        // Find the first note that has the given Id and an UserId that matches the requesting userId
        var eventEntity = await _dbContext.Events
            .FirstOrDefaultAsync(e =>
                e.EventId == eventId && e.UserId == _userId
                );

        // If eventEntity is null then return null, otherwise initialize and retun a new EventDetail
        return eventEntity is null ? null : new EventDetail
        {
            EventId = eventEntity.EventId,
            EventName = eventEntity.EventName,
            EventDescription = eventEntity.EventDescription,
            EventDate = eventEntity.EventDate,
            EventAddress = eventEntity.EventAddress
        };
    }
        public async Task<bool> UpdateEventAsync(EventUpdate request)
        {
            var eventEntity = await _dbContext.Events.FindAsync(request.Id);

            if(eventEntity?.UserId != _userId)
                return false;

                eventEntity.EventName = request.EventName;
                eventEntity.EventDescription = request.EventDescription;
                eventEntity.EventDate = request.EventDate;
                eventEntity.EventAddress = request.EventAddress;

                var numberOfChanges = await _dbContext.SaveChangesAsync();

                return numberOfChanges == 1;
        }

        public async Task<bool> DeleteEventAsync(int eventId)
        {
            var eventEntity = await _dbContext.Events.FindAsync(eventId);

            if(eventEntity?.UserId != _userId)
                return false;

                _dbContext.Events.Remove(eventEntity);
                return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}