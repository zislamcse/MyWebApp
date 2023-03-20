using DataAccessLayer.Data;
using DataAccessLayer.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitofWork;

        public CategoryController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            VMCategory category = new VMCategory(); 
            category.Categories = _unitofWork.Category.GetAll();
            return View(category);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CategoryModels _data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitofWork.Category.Add(_data);
        //        _unitofWork.Save();
        //        TempData["success"] = "Saved Successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(_data);
        //}

        public IActionResult CreateUpdate(int? id)
        {
            VMCategory vm = new VMCategory();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            vm.Category = _unitofWork.Category.GetT(z => z.Id == id);
            if (vm.Category == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(VMCategory vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Category.Id == 0)
                {
                    _unitofWork.Category.Add(vm.Category);
                    TempData["success"] = "Saved Successfully";
                }
                else
                {
                    _unitofWork.Category.Update(vm.Category);
                    TempData["success"] = "Updated Successfully";
                }
                _unitofWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitofWork.Category.GetT(z => z.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteData(int id)
        {
            var category = _unitofWork.Category.GetT(z => z.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitofWork.Category.Delete(category);
            _unitofWork.Save();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
