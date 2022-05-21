using System;

namespace NonProfitApp.Models.NPEntity
{
    public class NPEntityDetail
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}