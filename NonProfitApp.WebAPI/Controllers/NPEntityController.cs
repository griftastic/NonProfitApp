using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NonProfitApp.Services.NPEntity;
using NonProfitApp.Models.NPEntity;
using Microsoft.AspNetCore.Authorization;


namespace NonProfitApp.WebAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class NPEntityController : ControllerBase
        {
            private readonly INPEntityService _NPEntityService;
            public NPEntityController(INPEntityService NPEntityService)
            {
                _NPEntityService = NPEntityService;
            }

    // GET api/Event
        [HttpGet]
        public async Task<IActionResult> GetAllNPEntities()
        {
            var events = await _NPEntityService.GetAllNPEntitiesAsync();
            return Ok(nPEntities);
        }

    // POST api/Event
        [HttpPost]
        public async Task<IActionResult> CreateNPEnity([FromBody] NPEntityCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _eventService.CreateEventAsync(request))
                return Ok("NonProfit created successfully");

            return BadRequest("NonProfit could not be created.");
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

        return await _nPEntityService.UpdateNPEntityAsync(request)
            ? Ok ("NPEntity update successfully.")
            : BadRequest("NPEntity could not be updated.");

    }

    [HttpDelete("{NPEntityId:int}")]
    public async Task<IActionResult> DeleteNPEntity([FromRoute] int NPEntityId)
    {
        return await _nPEntityService.DeleteNPEntityAsync(nPEntityId)
        ? Ok($"NPEntity {nPEntityId} was deleted successfully.")
        : BadRequest($"NPEntity {nPEntityId} could not be deleted.");
    }
}
}

