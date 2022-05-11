using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NonProfitApp.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public bool NonProfitUser { get; set; }
    }
}