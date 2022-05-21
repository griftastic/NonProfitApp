using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitApp.Models.Event;
using NonProfitApp.Models.Note;
using NonProfitApp.Models.NPEntity;

namespace NonProfitApp.Services.NPEntity
{
    public interface INPEntityService
    {
        Task<bool> CreateNPEntityAsync(NPEntityCreate request);
        Task<IEnumerable<NPEntityListItem>> GetAllNPEntitiesAsync();
        Task<NPEntityDetail> GetNPEntityByIdAsync(int userId);
        Task<bool>UpdateNPEntityAsync(NPEntityUpdate request);
        Task<bool> DeleteNPEntityAsync(int nPEntityId);

    }
}