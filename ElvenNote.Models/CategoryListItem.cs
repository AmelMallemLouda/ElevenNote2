using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Display(Name = "Number of Notes")]
        public int NumOfNote { get; set; }
    }
}
