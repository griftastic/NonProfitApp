using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NonProfitApp.Data.Entities
{
    public class NonPEntity
    {
        [Key]
        public int NPEntityId { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}