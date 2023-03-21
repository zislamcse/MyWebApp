using DataAccessLayer.Data;
using DataAccessLayer.Infrastructure.IRepository;
using Models;

namespace DataAccessLayer.Infrastructure.Repository
{
    public class ProductRepository : Repository<ProductModels>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(ProductModels product)
        {
            var productDb = _context.Products.FirstOrDefault(z => z.Id == product.Id);
            if(productDb != null)
            {
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                productDb.ImageUrl = product.ImageUrl;
                productDb.CategoryId = product.CategoryId;
            }
        }
    }
}
