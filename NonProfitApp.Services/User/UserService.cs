using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data;
using NonProfitApp.Data.Entities;
using NonProfitApp.Models.User;

namespace NonProfitApp.Services.User
{
    public class UserService
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if(await GetUserByEmailAsync(model.Email) != null)
            return false;

            var entity = new UserEntity
            {
                Email = model.Email,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        private async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

    }
}