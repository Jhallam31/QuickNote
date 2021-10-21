using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Data.Tables
{
    public class Note
    {
        [Key]
        [Display(Name ="ID")]
        public int NoteId { get; set; }

        //ApplicationUserID will be the OwnerID
        [Required]
        [Display(Name = "Owner ID")]
        public string OwnerId { get; set; }
        public string Title { get; set; } = "(No Title)";

        [Required]
        public string Content { get; set; }
        
        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        //Category Foreign Key
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        
    }
}
