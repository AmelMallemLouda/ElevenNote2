using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class NoteCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Display(Name ="Category Id")]
        public int CategoryID { get; set; }
    }
}
