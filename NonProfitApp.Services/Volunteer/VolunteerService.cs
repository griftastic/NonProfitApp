using Microsoft.AspNetCore.Http;
using  System.Security.Claims;
using NonProfitApp.Data;
using NonProfitApp.Models.Volunteer;
using NonProfitApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace NonProfitApp.Services.Volunteer
{
    public class VolunteerService : IVolunteerService
    {
        private readonly int _volunteerId;
        private readonly ApplicationDbContext _dbContext;
        public VolunteerService(IHttpContextAccessor httpContextAccessor,ApplicationDbContext dbContext)
        {
            var userClaims =
                httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var value = userClaims.FindFirst("Id")?.Value;
                var validId = int.TryParse(value, out _volunteerId);
                if(!validId)
                throw new Exception("Attempted to build VolunteerServices without Id claim ");
                _dbContext = dbContext;
        }
        public async Task<IEnumerable<VolunteerListItems>> GetAllVolunteersAsync()
        {
            var volunteers = _dbContext.Volunteers
            .Where(entity => entity.UserId == _volunteerId)
            .Select(entity => new VolunteerListItems
            {
                VolunteerId = entity.VolunteerId,
                FirstName = entity.FirstName,
                LastName = entity.LastName
                
            })
            .ToList();
        return volunteers;
        }
        public async Task<bool> CreateVolunteerAsync(VolunteerCreate request)
        {
            var volunteerEntity = new VolunteerEntitiy
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserId = _volunteerId
            };
            _dbContext.Volunteers.Add(volunteerEntity);
            
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

    public async Task<VolunteerDetail> GetVolunteerByIdAsync(int volunteerId)
    {
        var volunteerEntity =await _dbContext.Volunteers
        .FindAsync(volunteerId);
        return volunteerEntity is null? null : new VolunteerDetail
        {
            VolunteerId = _volunteerId,
            FirstName = volunteerEntity.FirstName,
            LastName = volunteerEntity.LastName
        };
    }
public async Task<bool> UpdateVolunteerAsync(VolunteerUpdate request)
{
    var volunteerEntity = await _dbContext.Volunteers.FindAsync(request.volunteerId);
    if(volunteerEntity?.UserId != _volunteerId)
    return false;
    volunteerEntity.FirstName = request.FirstName;
    volunteerEntity.LastName = request.LastName;

    var numberOfChanges = await _dbContext.SaveChangesAsync();
    return numberOfChanges == 1;

    
}
    }
}