using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.NoteModels
{
    public class NoteListItem
    {
        [Display(Name = "ID")]
        public int NoteId { get; set; }
        public string Title { get; set; } = "(No Title)";
       
        [Display(Name ="Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
