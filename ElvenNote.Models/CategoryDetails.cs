using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class CategoryDetails
    {

        [Display(Name =" Category Id")]
        public int CategoryId { get; set; }

        [Display(Name = " Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Number of Notes")]
        public int NumOfNotes { get; set; }
        public List<NoteListItem> Notes { get; set; } = new List<NoteListItem>();
    }
}
