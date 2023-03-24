using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models
{
    public class ProductModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public CategoryModels Category { get; set; }
    }
}
