using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.NoteModels
{
    public class NoteEdit
    {
        [Display(Name ="Note ID")]
        public int NoteId { get; set; }
        public string Title { get; set; } = "(No Title)";
        public string Content { get; set; }
        
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
