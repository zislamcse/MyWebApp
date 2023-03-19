using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CategoryModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Required(ErrorMessage = "Enter Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
