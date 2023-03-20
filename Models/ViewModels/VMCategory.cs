namespace Models.ViewModels
{
    public class VMCategory
    {
        public CategoryModels Category { get; set; } = new CategoryModels();
        public IEnumerable<CategoryModels> Categories { get; set; } = new List<CategoryModels>();
    }
}
