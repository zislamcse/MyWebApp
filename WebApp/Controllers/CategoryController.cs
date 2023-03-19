using DataAccessLayer.Data;
using DataAccessLayer.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitofWork;

        public CategoryController(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CategoryModels> categories = _unitofWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModels _data)
        {
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Add(_data);
                _unitofWork.Save();
                TempData["success"] = "Saved Successfully";
                return RedirectToAction("Index");
            }
            return View(_data);
        }

        public IActionResult Edit(int id)
        {
            if(id == null || id == 0)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryModels _data)
        {
            if(ModelState.IsValid)
            {
                _unitofWork.Category.Update(_data);
                _unitofWork.Save();
                TempData["success"] = "Updated Successfully";
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
            if(category == null)
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
