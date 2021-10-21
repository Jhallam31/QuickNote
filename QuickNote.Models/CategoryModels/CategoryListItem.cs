using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.CategoryModels
{
    public class CategoryListItem
    {
        [Display(Name ="ID")]
        public int CategoryId { get; set; }

        [Display(Name ="Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Notes in Collection")]
        public int NoteCount { get; set; }
    }
}
