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
        [Display(Name = " Category Id")]
        public int CategoryId { get; set; }

        [Display(Name = " Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Number of Notes")]
        public int NumOfNote { get; set; }
    }
}
