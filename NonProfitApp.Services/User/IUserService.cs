using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitApp.Models.User;

namespace NonProfitApp.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
        Task<UserDetail> GetUserByIdAsync(int userId);
    }
}