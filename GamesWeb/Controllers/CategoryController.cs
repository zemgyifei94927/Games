using Games.DataAccess.Data;
using Games.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {   
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "This is a custom validation. Dispaly order can not be the same as Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index", "Category");
            }
            
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category categoryFromDb3 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();

            if(categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "This is a custom validation. Dispaly order can not be the same as Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully.";
                return RedirectToAction("Index", "Category");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            //Category categoryFromDb2 = _db.Categories.FirstOrDefault(c => c.Id == id);
            //Category categoryFromDb3 = _db.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //if(category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "This is a custom validation. Dispaly order can not be the same as Name.");
            //}
            Category? categoryFromDb = _db.Categories.Find(id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDb);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index", "Category");
        }
    }
}
