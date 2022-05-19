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
        Task<bool> CreateNoteAsync(NoteCreate request);
        Task<IEnumerable<NoteListItem>> GetAllNotesAsync();
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

             }
         }
    }
}