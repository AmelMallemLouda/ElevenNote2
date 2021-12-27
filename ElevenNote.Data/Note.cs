using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElvenNote.Data
{
    public class Note
    {
        [Key]//This attribute specifies the property that uniquely identifies an entity. In other words, it's the primary key of the corresponding database
        public int NoteId { get; set; }
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
