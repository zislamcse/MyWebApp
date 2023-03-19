using DataAccessLayer.Data;
using DataAccessLayer.Infrastructure.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<CategoryModels>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CategoryModels category)
        {
            _context.Categories.Update(category);
        }
    }
}
