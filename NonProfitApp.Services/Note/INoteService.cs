using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace NonProfitApp.Services.Note
{
    public interface INoteService
    {   
        public class NoteService : INoteService
        {
            private readonly int _userId;
             public NoteService(IHttpContextAccessor httpContextAccessor)
             {
                var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var value = userClaims.FindFirst("Id")?.Value;
                var validId =int.TryParse(value, out _userId);
                if (!validId)
                    throw new Exception("Attempted to build NoteService without User Id claim.");
             }
         }
    }
}