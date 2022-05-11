using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NonProfitApp.Data;
using NonProfitApp.Data.Entities;
using NonProfitApp.Models.User;
using Microsoft.AspNetCore.Identity;
using NonProfitApp.Services.User;

namespace NonProfitApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context; 
        }

        public async Task<bool> RegisterUserAsync(UserRegister model)
        {
            if (await GetUserByEmailAsync(model.Email) != null)
            return false;

            var entity = new UserEntity
            {
                Email = model.Email,
                DateCreated = DateTime.Now
            };

            // var passwordHasher = new PasswordHasher<UserEntity>();
            // entity.Password = passwordHasher.HashPassword(entity,model.Password);

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            var entity = await _context.Users.FindAsync(userId);
            if(entity is null)
            return null;

            var userDetail = new UserDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateCreated = entity.DateCreated
            };
            return userDetail;
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        // Task<UserDetail> IUserService.GetUserByEmailAsync(string email)
        // {
        //     throw new NotImplementedException();
        // }
    }
}