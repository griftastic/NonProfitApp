using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonProfitApp.Services.NPEnity;
using NonProfitApp.Models.NPEnity;
using Microsoft.AspNetCore.Authorization;


namespace NonProfitApp.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class NPEntityController : ControllerBase
        {
            private readonly INoteService _NPEntityService;
            public NPEntityController(INoteService NPEntityService)
            {
                _NPEntityService = NPEntityService;
            }

    // GET api/Event
        [HttpGet]
        public async Task<IActionResult> GetAllNPEntity()
        {
            var events = await _NPEntityService.GetAllNPEntityAsync();
            return Ok(events);
        }

    // POST api/Event
        [HttpPost]
        public async Task<IActionResult> CreateNPEnity([FromBody] NPEntityCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _eventService.CreateEventAsync(request))
                return Ok("Note created successfully");

            return BadRequest("Note could not be created.");
        }
    // Get api/Event/6
    [HttpGet("{NonProfitId:int}")]
    public async Task<IActionResult> GetEventById([FromRoute] int NonProfitId)
    {
        var detail = await _NPEntityService.GetNPEntityByIdAsync(NonProfitId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateNPEntityById([FromBody] NPEntityUpdate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return await _noteService.UpdateNPEntityAsync(request)
            ? Ok ("NPEntity update successfully.")
            : BadRequest("NPEntity could not be updated.")

    }
    [HttpDelete("{NPEntityId:int}")]
    public async Task<IActionResult> DeleteNote([FromRoute] int NPEntityId)
        {
            return await _NPEntityService.DeleteNPEntityAsync(NPEntityId)
                ? Ok ($ "Note {NPEntityId} was deleted successfully.")
                : BadRequest ($ "Note {NPEntityId} could not be deleted.")
        }
    }
}