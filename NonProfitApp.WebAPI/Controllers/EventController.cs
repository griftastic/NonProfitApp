using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonProfitApp.Services.Event;
using NonProfitApp.Models.Event;
using Microsoft.AspNetCore.Authorization;


namespace NonProfitApp.WebAPI.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class EventController : ControllerBase
        {
            private readonly IEventService _eventService;
            public EventController(IEventService eventService)
            {
                _eventService = eventService;
            }

    // GET api/Event
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EventListItem>), 200)]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            return Ok(events);
        }

    // POST api/Event
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _eventService.CreateEventAsync(request))
                return Ok("Event created successfully");

            return BadRequest("Event could not be created.");
        }
    // Get api/Event/6
    [HttpGet("{eventId:int}")]
    public async Task<IActionResult> GetEventById([FromRoute] int eventId)
    {
        var detail = await _eventService.GetEventByIdAsync(eventId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }

    // PUT api/Event
    [HttpPut]
    public async Task<IActionResult> UpdateEventById([FromBody] EventUpdate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _eventService.UpdateEventAsync(request)
            ? Ok("Event updated successfully")
            : BadRequest("Event could not be updated.");
    }

    [HttpDelete("{eventId:int}")]
    public async Task<IActionResult> DeleteEvent([FromRoute] int eventId)
    {
        return await _eventService.DeleteEventAsync(eventId)
        ? Ok($"Event {eventId} was deleted successfully.")
        : BadRequest($"Event {eventId} could not be deleted.");
    }
    }
}