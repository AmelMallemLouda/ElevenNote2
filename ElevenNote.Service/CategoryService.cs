using ElevenNote.Data;
using ElvenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Service
{
    public class CategoryService
    {

        private readonly Guid _userId;

        public CategoryService(Guid userID)
        {
            _userId = userID;
        }
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    OwnerID = _userId,
                    CategoryName = model.Name,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                            .Categories
                            .Where(e => e.OwnerID == _userId)
                            .Select(
                                e =>
                                    new CategoryListItem
                                    {
                                        CategoryId= e.CategoryId,
                                        CategoryName = e.CategoryName,
                                        NumOfNote = e.Notes.Count()
                                    }
                    ).ToList();
                return query;
            }
        }


        public CategoryDetails GetCategoryByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == id && e.OwnerID == _userId)
                        .FirstOrDefault();
                return
                    new CategoryDetails
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        NumOfNotes = entity.Notes.Count(),
                        Notes = entity.Notes
                                .Select(
                                    x => new NoteListItem
                                    {
                                        NoteId = x.NoteId,
                                        Title = x.Title,
                                    }
                                ).ToList()
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit category)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == category.CategoryId && e.OwnerID == _userId)
                        .FirstOrDefault();
                entity.CategoryName = category.CategoryName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Where(e => e.CategoryId == id && e.OwnerID == _userId)
                        .FirstOrDefault();
                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
