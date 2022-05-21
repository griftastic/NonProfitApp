using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NonProfitApp.Services.Volunteer;
using NonProfitApp.Models.Volunteer;


namespace NonProfitApp.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerController : ControllerBase
    {
        private readonly IVolunteerService _volunteerService;
        public VolunteerController(IVolunteerService volunteerService)
        {
            _volunteerService = volunteerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVolunteers()
        {
            var volunteers = await _volunteerService.GetAllVolunteersAsync();
            return Ok(volunteers); 
        }
        [HttpPost]
        public async Task<IActionResult> CreateVolunteers([FromBody] VolunteerCreate request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if(await _volunteerService.CreateVolunteerAsync(request))
            return Ok("Note created Successfully.");
        return BadRequest("Notes could not be created.");
        }
        [HttpGet("{volunteerId:int}")]
        public async Task<IActionResult> GetVolunteerById([FromRoute] int volunteerId)
        {
            var detail = await _volunteerService.GetVolunteerByIdAsync(volunteerId);
                return detail is not null? 
                Ok(detail)
                :NotFound();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVolunteerById([FromBody] VolunteerUpdate request)
        {
        if(!ModelState.IsValid)
                return BadRequest(ModelState);
        return await _volunteerService.UpdateVolunteerAsync(request)
        ?Ok("Note Updated Successfully")
        :BadRequest("Note couldnt be updated");
        }
    } 
}
