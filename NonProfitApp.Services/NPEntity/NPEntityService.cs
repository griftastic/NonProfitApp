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
using NonProfitApp.Models.Note;
using NonProfitApp.Models.NPEntity;

namespace NonProfitApp.Services.NPEntity
{
    public class NPEntityService : INPEntityService
    {   
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public NPEntityService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
            {
                var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var value = userClaims.FindFirst("Id")?.Value;
                var validId =int.TryParse(value, out _userId);
                if (!validId)
                    throw new Exception("Attempted to build NPEntityService without User Id claim.");
                _dbContext = dbContext;
            }
            public async Task<bool> CreateNPEntityAsync(NPEntityCreate request)
            {
                var nPEntity = new NonPEntity
                {
                    Title = request.Title,
                    Content = request.Content,
                    CreatedUtc = DateTimeOffset.Now,
                    UserId = _userId
                };

                _dbContext.NPEntities.Add(nPEntity);

                var numberOfChanges = await _dbContext.SaveChangesAsync();
                return numberOfChanges ==1;
            }

            public async Task<IEnumerable<NPEntityListItem>> GetAllNPEntitiesAsync()
            {
                var nPEntities = await _dbContext.NPEntities
                    .Where(entity => entity.UserId == _userId)
                    .Select(entity => new NPEntityListItem
                    {
                        Id = entity.NPEntityId,
                        Title = entity.Title,
                        CreatedUtc = entity.CreatedUtc
                    })
                    .ToListAsync();
                return nPEntities;
            }


            public async Task<NPEntityDetail> GetNPEntityByIdAsync(int nPEntityId)
            {
                var nPEntityEntity = await _dbContext.NPEntities
                    .FirstOrDefaultAsync(e =>
                    e.NPEntityId == nPEntityId && e.UserId == _userId
                    );

                return nPEntityEntity is null ? null : new NPEntityDetail
                {
                    UserId = nPEntityEntity.UserId,
                    Title = nPEntityEntity.Title,
                    Content = nPEntityEntity.Content,
                    CreatedUtc = nPEntityEntity.CreatedUtc,
                    ModifiedUtc = nPEntityEntity.ModifiedUtc,
                };
            }
            // Get api/ NPEntity/5
            public async Task<bool> UpdateNPEntityAsync(NPEntityUpdate request)
                {
                    var nPEntityEntity = await _dbContext.NPEntities.FindAsync(request.Id);

                if (nPEntityEntity?.UserId != _userId)
                    return false;
                
                nPEntityEntity.Title = request.Title;
                nPEntityEntity.Content = request.Content;
                nPEntityEntity.ModifiedUtc = DateTimeOffset.Now;

                var numberOfChanges = await _dbContext.SaveChangesAsync();
                return numberOfChanges ==1;
                }
            public async Task<bool> DeleteNPEntityAsync(int nPEntityId)
                {
                    var nPEntityEntity = await _dbContext.NPEntities.FindAsync(nPEntityId);

                    if(nPEntityEntity?.UserId != _userId)
                        return false;

                        _dbContext.NPEntities.Remove(nPEntityEntity);
                        return await _dbContext.SaveChangesAsync() == 1;
                }

    }
        }