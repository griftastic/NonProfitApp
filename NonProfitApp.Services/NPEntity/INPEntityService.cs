using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NonProfitApp.Models.Note;
using System.Security.Claims;
using NonProfitApp.Data;

namespace NonProfitApp.Services.Note

{
    public interface INoteService
    {   
        Task<bool> DeleteNPEntityAsync(int NPEntityId);
        Task<bool>UpdateNPEntityAsync(NPEventUpdate request);
        Task<bool> CreateNPENtityAsync(NPEntityCreate request);
        Task<IEnumerable<NPEntityListItem>> GetAllNotesAsync();
        Task<NoteDetail> GetNPEntityByIdAsnc(int userId);
        public class NoteService : INoteService
        {
            private readonly int _userId;
            private readonly ApplicationDbContext _dbContext;
            public NoteService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
             {
                var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var value = userClaims.FindFirst("Id")?.Value;
                var validId =int.TryParse(value, out _userId);
                if (!validId)
                    throw new Exception("Attempted to build NoteService without User Id claim.");
                _dbContext = dbContext;
             }
             public async Task<bool> CreateNoteAsync(NoteCreate request)
             {
                 var noteEntity = new NoteEntity
                 {
                     Type = request.Title,
                     Content = request.Content,
                     CreateUtc = DateTimeOffset.Now,
                     OwnerId = _userID
                 };

                 _dbContext.Notes.Add(noteEntity);

                 var numberOfChanges = await _dbContext.SaveChangesAsync();
                 rreturn numberOfChanges ==1;
             }

             [HttpGet]
             public async Task<IActionResults> Get AllNotes()
             {
                 var notes = await _noteService.GetAllNotesAsync();
                 return DayOfWeek(notes);
             }
             public async Task<IEnumerable<NoteListItem>> GetAllNotesAsync()
             {
                 var notes = await _dbContext.Notes
                    .Where(entity => entity.OwnedId == _userId)
                    .Select(entity => new NoteListItem
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        CreatedUtc = entity.CreatedUtc
                    })
                    .ToListAsync();
                return notes;
            public async Task<NoteDetail> GetNoteIdAsync(int noteId)
            {
                var noteEntity = await _dbContext.Notes
                    .FirstOrDefultAsync(e =>
                    e.Id && e.OwnerId == _userId
                    );

            return noteEntity is null ? null : new NoteDetail
            {
                Id = noteIdEntity.Id,
                Title = noteEntity.Title,
                Content = noteEntity.Content,
                CreatedUtc = noteEntity.CreatedUtc,
                ModifiedUtc = noteEntity.ModifiedUtc,
            };
            // Get api/ NPEntity/5
            [HttpGet("{UserId:int")]
            public async Task<IActionResult> GetNPEntityById([FromRoute] int UserId)
            {
                var details = await _NPEntityService.GetNPEntityByIdAsync(UserId);
                return details in not null
                    ? Ok (detail)
                    : DllNotFoundException ();
            }
            public async Task<bool> UpdateNPEntityAsync(NPEntityUpdate request)
            {
                var NPEntityEntity = await _dbContext.NPEntity.FindAsync(request.Id);

            if (NPEntityEntity?.OwnedId != _userId)
                return false;
            
            NPEntityEntity.TItle = request.Title;
            NPEntityEntity.Content = request.Content;
            NPEntityEntity.ModifiedUtc = DateTimeOffset.Now;

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges ==1;
            }
            }
        }
        }
    }
}