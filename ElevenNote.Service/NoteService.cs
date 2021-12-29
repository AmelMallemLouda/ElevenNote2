using ElevenNote.Data;
using ElvenNote.Data;
using ElvenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Service
{
    public class NoteService
    {
        //private field of type Guid called, to make sure that only the user logged in can access to his notes
        private readonly Guid _userId;

        //constructor
        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CrerateNote(NoteCreate model)
        {
            var entity = new Note()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now,
                CategoryId = model.CategoryID
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        //IEnumerator is an interface which helps to get current elements from the collection
        public IEnumerable<NoteListItem> GetNotes()
        {

            //use ctx to access our database then we select the note table , we want our user to be be the same as the person who is logged in. we new up an instance of NoteListItem and pick the propreties that we want from the database.
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Notes.Where(e => e.OwnerId == _userId)
                    .Select(
                    e => new NoteListItem
                    {
                        NoteId = e.NoteId,
                        Title = e.Title,
                        IsStarred=e.IsStarred,
                        CreatedUtc = e.CreatedUtc,
                        CategoryName = e.Category.CategoryName
                    });

                return query.ToArray();
            }
        }


        public NoteDetails GetNoteById(int id)
        {
            using(var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Notes.Single(e => e.NoteId == id && e.OwnerId == _userId);
                return  new NoteDetails
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                  CategoryId = entity.CategoryId,
                    CategoryName = entity.Category.CategoryName,
                };
            }
        }

        public bool UpdateNote(NoteEdit note)
        {

            //use ApplicationDbContext to access our database
            using(var ctx=new ApplicationDbContext())
            {

                //access the note table make sure we look for the note we want to update using the note Id and the user who is updating the note is the one who is logged in
                var entity = ctx.Notes.Single(e => e.NoteId == note.NoteId && e.OwnerId == _userId);

                //make the changes
                entity.Title = note.Title;
                entity.Content = note.Content;
                entity.ModifiedUtc = DateTimeOffset.Now;
                entity.CategoryId = note.CategoryID;
                entity.IsStarred = note.IsStarred;
                //save the changes
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int id)
        {
            using( var ctx= new ApplicationDbContext())
            {
                var entity = ctx.Notes.Single(e => e.NoteId ==id && e.OwnerId == _userId);
                ctx.Notes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    
    
    
    
    
    }


}
