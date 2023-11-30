using Games.DataAccess.Data;
using Games.Models;
using Microsoft.AspNetCore.Mvc;
using Games.DataAccess.Repository.IRepository;

namespace GamesWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        //private readonly ICategoryRepository _categoryRepo;
        private readonly IUnitofWork _unitofWork;
        public CategoryController(IUnitofWork unitofWork) 
        {
            _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {   
            List<Category> objCategoryList = _unitofWork.Category.GetAll().ToList();
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
                _unitofWork.Category.Add(category);
                _unitofWork.Save();
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
            Category categoryFromDb = _unitofWork.Category.Get(u => u.Id == id);
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
                _unitofWork.Category.Update(category);
                _unitofWork.Save();
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
            Category categoryFromDb = _unitofWork.Category.Get(u => u.Id == id);
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
            Category? categoryFromDb = _unitofWork.Category.Get(u => u.Id == id);
            if(categoryFromDb == null)
            {
                return NotFound();
            }
            _unitofWork.Category.Remove(categoryFromDb);
            _unitofWork.Save();
            TempData["success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index", "Category");
        }
    }
}
