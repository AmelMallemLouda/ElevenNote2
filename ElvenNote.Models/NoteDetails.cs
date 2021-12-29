using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class NoteDetails
    {

        public int NoteId { get; set; }
     
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

        [Display(Name = " Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
    }
}
