using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NonProfitApp.Models.Token;

namespace NonProfitApp.Services.Token
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync(TokenRequest model);
    }
}