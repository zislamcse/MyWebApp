using DataAccessLayer.Infrastructure.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}
