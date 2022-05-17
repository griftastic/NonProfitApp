using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NonProfitApp.Models.Token
{
    public class TokenRequest
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}