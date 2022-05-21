using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NonProfitApp.Data.Entities
{
    public class VolunteerEntitiy
    {
        [Key]
        public int VolunteerId { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set;}
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Password { get; set; }
        [EmailAddress]
        public string? Email   { get; set; }
        public DateTime DateAvailable { get; set; } 
        public DateTime DateCreated { get; set; }
        public double ZipCode { get; set; }
    }
}