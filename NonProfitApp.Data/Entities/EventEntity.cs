using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NonProfitApp.Data.Entities
{
    public class EventEntity
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set;}
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string EventAddress { get; set; }
        public List<EventEntity> Events { get; set; }
    }
}