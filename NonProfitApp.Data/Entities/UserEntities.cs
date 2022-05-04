using System.ComponentModel.DataAnnotations;

namespace NonProfitApp.Data.Entities

{
    public class UserEntity
    {
        [Key]
        public int VolunteerId{get;set;}

        [Required]
        public string Email{get;set;}

        [Required]
        public string Username{get;set;}

        [Required]
        public string Password{get;set;}
        public string FirstName{get; set;}
        public string LastName{get;set;}

        [Required]
        public DateTime DateAvailable{get;set;}

        [Required]
        public DateTime DateCreated{get;set;}

        [Required]
        public double ZipCode{get;set;}
    }
}