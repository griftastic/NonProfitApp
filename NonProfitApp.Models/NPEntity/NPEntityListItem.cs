using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NonProfitApp.Models.Note
{
    public class NPEntityListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}