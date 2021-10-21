using QuickNote.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.CategoryModels
{
    public class CategoryDetail
    {
        [Display(Name ="ID")]
        public int CategoryId { get; set; }

        [Display(Name ="Category")]
        public string CategoryName { get; set; }

        [Display(Name = "Notes in Collection")]
        public int NoteCount { get; set; }

        [Display(Name ="Notes")]
        public ICollection<Note> NotesInThisCategory { get; set; }

    }
}
