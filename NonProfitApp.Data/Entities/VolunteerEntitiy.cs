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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email   { get; set; }
        [Required]
        public DateTime DateAvailable { get; set; } 
        public DateTime DateCreated { get; set; }
        public double ZipCode { get; set; }
    }
}