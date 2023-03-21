using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class VMProduct
    {
        public ProductModels Product { get; set; } = new ProductModels();
        [ValidateNever]
        public IEnumerable<ProductModels> Products { get; set; } = new List<ProductModels>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
