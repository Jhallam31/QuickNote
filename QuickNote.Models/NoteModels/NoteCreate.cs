using QuickNote.Data.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Models.NoteModels
{
    public class NoteCreate
    {

        //ApplicationUserID will be the OwnerID
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }

        //Category reference
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        


    }
}
