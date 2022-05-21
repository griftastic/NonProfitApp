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
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
        public class NPEntityController : ControllerBase
        {
            private readonly INPEntityService _nPEntityService;
            public NPEntityController(INPEntityService nPEntityService)
            {
                _nPEntityService = nPEntityService;
            }

    // GET api/Event
        [HttpGet]
        public async Task<IActionResult> GetAllNPEntities()
        {
            var nPEntitiess = await _nPEntityService.GetAllNPEntitiesAsync();
            return Ok(nPEntitiess);
        }

    // POST api/Event
        [HttpPost]
        public async Task<IActionResult> CreateNPEnity([FromBody] NPEntityCreate request)
        {
            if (!ModelState.IsValid)
            return BadRequest(ModelState);

            if (await _nPEntityService.CreateNPEntityAsync(request))
                return Ok("NonProfit created successfully");

            return BadRequest("NonProfit could not be created.");
        }
    // Get api/Event/6
    [HttpGet("{NonProfitId:int}")]
    public async Task<IActionResult> GetNPEntityById([FromRoute] int NonProfitId)
    {
        var detail = await _nPEntityService.GetNPEntityByIdAsync(NonProfitId);

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
    public async Task<IActionResult> DeleteNPEntity([FromRoute] int nPEntityId)
    {
        return await _nPEntityService.DeleteNPEntityAsync(nPEntityId)
        ? Ok($"NPEntity {nPEntityId} was deleted successfully.")
        : BadRequest($"NPEntity {nPEntityId} could not be deleted.");
    }
}
}

