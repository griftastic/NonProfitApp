using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using NonProfitApp.Models.Volunteer;


namespace NonProfitApp.Services.Volunteer
{
    public interface IVolunteerService
    {
        Task<bool>CreateVolunteerAsync(VolunteerCreate request);
        Task<IEnumerable<VolunteerListItems>> GetAllVolunteersAsync();
        Task<VolunteerDetail> GetVolunteerByIdAsync(int volunteerId);
        Task<bool> UpdateVolunteerAsync (VolunteerUpdate request);
        
    }
}