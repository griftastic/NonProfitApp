using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NonProfitApp.Models.Event
{
    public class EventUpdate
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters.")]

        public string NonProfitName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters.")]
        public string EventName { get; set; }

        [Required]
        [MinLength(100, ErrorMessage ="{0} must be at least {1} characters long.")]
        [MaxLength(1000, ErrorMessage = "{0} must be no more than {1} characters.")]
        public string EventDescription { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [MinLength(2, ErrorMessage ="{0} must be at least {1} characters long.")]
        [MaxLength(100, ErrorMessage = "{0} must be no more than {1} characters.")]
        public string EventAddress { get; set; }

    }
}