using DataAccessLayer.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostEnv;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnv)
        {
            _unitOfWork = unitOfWork;
            _hostEnv = hostEnv;
        }

        public IActionResult Index()
        {
            VMProduct vm = new VMProduct();
            vm.Products = _unitOfWork.Product.GetAll();
            return View(vm);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            VMProduct vm = new VMProduct()
            {
                Product = new(),
                Categories = _unitOfWork.Category.GetAll().Select(z =>
                new SelectListItem()
                {
                    Text = z.Name,
                    Value = z.Id.ToString(),
                })
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(VMProduct vm, IFormFile? file)
        {
            if(ModelState.IsValid)
            {
                var fileName = "";
                if(file != null)
                {
                    string uploadDir = Path.Combine(_hostEnv.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);
                    using(var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    vm.Product.ImageUrl = @"\ProductImage\" + fileName;
                }

                if(vm.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(vm.Product);
                    TempData["success"] = "Saved Successfully";
                }
                else
                {
                    _unitOfWork.Product.Update(vm.Product);
                    TempData["success"] = "Updated Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
