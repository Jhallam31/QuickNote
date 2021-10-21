using QuickNote.Data;
using QuickNote.Data.Tables;
using QuickNote.Models.NoteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuickNote.Services
{

    public class NoteService
    {
        private readonly string _userId;


        public NoteService(string userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate model)
        {
                    ApplicationDbContext ctx = new ApplicationDbContext();
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId=model.CategoryId,
                    CreatedUtc = DateTimeOffset.Now
                };

            
                ctx.Notes.Add(entity);
            
                return ctx.SaveChanges() == 1;
            
        }

        public IEnumerable<NoteListItem> GetAllNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Notes
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new NoteListItem
                        {
                            NoteId = e.NoteId,
                            Title = e.Title,
                            CategoryName=e.Category.CategoryName,
                            CreatedUtc=e.CreatedUtc,
                            ModifiedUtc= e.ModifiedUtc
                        });
                return query.ToArray();
            }
        }

        public NoteDetail GetNoteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Notes
                    .Single(e => e.NoteId == id);
                return
                    new NoteDetail
                    {
                        NoteId = entity.NoteId,
                        OwnerId = entity.OwnerId,
                        Title = entity.Title,
                        Content = entity.Content,
                        CategoryName=entity.Category.CategoryName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };

            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Notes
                    .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.CategoryId = model.CategoryId;
                entity.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteId == id);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        //Helper to get list of Categories
        public List<SelectListItem> GetCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            using (var ctx = new ApplicationDbContext())
            {
                categories = ctx.Categories.Select(
                    c =>
                    new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    }).ToList();
                return categories;
            }
        }

    }
}
