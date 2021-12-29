﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Models
{
    public class NoteListItem
    {

        public int NoteId { get; set; }
      
        public string Title { get; set; }

        [UIHint("Starred")] //will link up to a view we make later
        public bool IsStarred { get; set; }


        [Display (Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string CategoryName { get; set; }

    }
}
