using Games.DataAccess.Data;
using Games.Models;
using Microsoft.AspNetCore.Mvc;
using Games.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Games.Models.ViewModels;
using Games.Utility;
using Microsoft.AspNetCore.Authorization;

namespace GamesWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        //private readonly ICategoryRepository _categoryRepo;
        private readonly IUnitofWork _unitofWork;
        
        public CompanyController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitofWork.Company.GetAll().ToList();

            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyobj = _unitofWork.Company.Get(u => u.Id == id);
                return View(companyobj);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {

            if (ModelState.IsValid)
            {
                
                if (CompanyObj.Id == 0)
                {
                    _unitofWork.Company.Add(CompanyObj);
                }
                else
                {
                    _unitofWork.Company.Update(CompanyObj);
                    
                }
                _unitofWork.Save();
                TempData["success"] = "Company Updated Successfully.";
                return RedirectToAction("Index", "Company");
            }
            else
            {
                return View(CompanyObj);
            }

        }

        #region
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitofWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id) 
        {
            var CompanyToBeDeleted = _unitofWork.Company.Get(u => u.Id == id);
            if(CompanyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            
            _unitofWork.Company.Remove(CompanyToBeDeleted);
            _unitofWork.Save();

            return Json(new { success = true, message = "Delete Successfully" });

        }
        #endregion
    }
}
