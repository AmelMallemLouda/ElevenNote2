using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class NoteEdit
    {
        [Display(Name = " Note Id")]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryID { get; set; }
        public bool IsStarred { get; set; }
    }
}
