using System.ComponentModel.DataAnnotations;

namespace NonProfitApp.Models.Volunteer
{
    public class VolunteerUpdate
    {
        [Required]
        [MinLength(2,ErrorMessage = "{0} must be at least one character long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} character.")]
        public string FirstName{ get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "{0} must be at least one character long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} character.")]
        public string LastName { get; set; }
        public int volunteerId {get; set;}

    }
}