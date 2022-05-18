using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    }
}