using QuickNote.Data;
using QuickNote.Data.Tables;
using QuickNote.Models.CategoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickNote.Services
{
    public class CategoryService
    {


        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    CategoryName = model.CategoryName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Where(e => e.CategoryId == e.CategoryId)
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryId = e.CategoryId,
                            CategoryName = e.CategoryName,
                            NoteCount = ctx.Notes.Where(n=>n.CategoryId == e.CategoryId).Count()
                        });
                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var categoriesWithNotes = ctx.Categories.Include("NotesInThisCategory");
                var entity =
                    categoriesWithNotes
                    .Single(e => e.CategoryId == id);

                if (entity.NotesInThisCategory != null)
                {
                    return
                        new CategoryDetail
                        {
                            CategoryId = entity.CategoryId,
                            CategoryName = entity.CategoryName,
                            NoteCount = ctx.Notes.Where(n => n.CategoryId == entity.CategoryId).Count(),
                            NotesInThisCategory = ctx.Notes.Where(n => n.CategoryId == id).ToList()
                        };
                }
                else
                {
                    
                    return
                        new CategoryDetail
                        {
                            CategoryId = entity.CategoryId,
                            CategoryName = entity.CategoryName,
                            NoteCount = 0
                            
                            
                        };
                }

            };

        }
        public CategoryDetail GetCategoryByName(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryName == name);
                if (entity.NotesInThisCategory != null)
                {
                    return
                        new CategoryDetail
                        {
                            CategoryId = entity.CategoryId,
                            CategoryName = entity.CategoryName,
                            NoteCount = entity.NotesInThisCategory.Count(),
                            NotesInThisCategory = entity.NotesInThisCategory.ToArray()
                        };
                }
                else
                {
                    return
                        new CategoryDetail
                        {
                            CategoryId = entity.CategoryId,
                            CategoryName = entity.CategoryName,
                            NoteCount = entity.NotesInThisCategory.Count(),

                        };
                }

            };

        }


        public bool UpdateCategory(CategoryEdit model, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Categories
                    .Single(e => e.CategoryId == id);

                entity.CategoryName = model.CategoryName;

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
                        .Single(e => e.CategoryId == id);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}

