using Microsoft.AspNet.Identity;
using QuickNote.Data;
using QuickNote.Data.Tables;
using QuickNote.Models.CategoryModels;
using QuickNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickCategory.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            CategoryService service = CreateCategoryService();
            var model = service.GetAllCategories();

            return View(model);
        }

        //GET: CategoryCreate
        public ActionResult Create()
        {
            return View();
        }

        //POST: Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCategoryService();

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be created.");

            return View(model);
        }

        //GET: CategoryDetail
        [HttpGet]

        public ActionResult Details(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            
   ////***extra code for NotesInThisCategory

   //         //Locate the correct instance of Category
   //         var ctx = new ApplicationDbContext();
   //         var entity =
   //             ctx
   //                 .Categories
   //                 .Single(e => e.CategoryId == id);

   //         //Create a list to hold the data from category.NotesInThisCategory
   //         List<Note> notesInThisCategory = new List<Note>();

   //         //null check
   //         if(notesInThisCategory != null)
   //         {
   //         //Set value of List to the entity's collection of Notes
   //         notesInThisCategory = entity.NotesInThisCategory.ToList();

   //         //Create ViewBag so that the data can be passed to the view
   //         ViewBag.NotesInThisCategory = notesInThisCategory;
   //         }

            return View(model);
        }

        //GET: CategoryUpdate
        [HttpGet]

        public ActionResult Edit(int id)
        {
            var service = CreateCategoryService();
            var detail = service.GetCategoryById(id);
            var model =
                new CategoryEdit
                {
                    CategoryId = detail.CategoryId,
                    CategoryName = detail.CategoryName,

                };
            return View(model);
        }

        //POST:CategoryEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCategoryService();

            if (service.UpdateCategory(model, id))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        //GET:DeleteCategory
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCategoryService();
            var model = svc.GetCategoryById(id);

            return View(model);
        }

        //POST:Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCategoryService();

            service.DeleteCategory(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }


        //Helper method(s)
        private CategoryService CreateCategoryService()
        {

            var service = new CategoryService();
            return service;
        }
    }
}