using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repo;
        public CategoryController(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var categories = repo.GetAllCategories();
            return View(categories);
        }

        public IActionResult ViewCategory(int id)
        {
            var category = repo.GetCategory(id);

            return View(category);
        }

        //public IActionResult UpdateCategory(int id)
        //{
        //    Category cat = repo.GetCategory(id);

        //    if (cat == null)
        //    {
        //        return View("CategoryNotFound");
        //    }
        //    return View(cat);
        //}

        //public IActionResult UpdateCategoryToDatabase(Category category)
        //{
        //    repo.UpdateCategory(category);

        //    return RedirectToAction("ViewCategory", new { id = category.CategoryID });
        //}

        //public IActionResult InsertCategory()
        //{
        //    var cat = repo.AssignDepartment();

        //    return View(cat);
        //}

        //public IActionResult InsertCategoryToDatabase(Category categoryToInsert)
        //{
        //    repo.InsertCategory(categoryToInsert);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult DeleteCategory(Category category)
        //{
        //    repo.DeleteCategory(category);

        //    return RedirectToAction("Index");
        //}
    }
}
