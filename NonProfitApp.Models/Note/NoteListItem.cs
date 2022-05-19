using System;
namespace NonProfitApp.Models.Note
{
    public class NoteListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}