using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NonProfitApp.Data.Entities
{
    public class NPEnitiy
    {
        [Key]
        public int NonProfitId { get; set;}
        
        [Required]
        [ForeignKey (nameof (User))]
        public int UserId { get; set; }
        public UserEntity User;

        public int Mission { get; set;}

        [Required]
        public int TaxDeductable {get; set;}
        
        [Required]
        public int Email { get; set;}
    }
}