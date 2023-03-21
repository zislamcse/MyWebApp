using Microsoft.EntityFrameworkCore.Update.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Infrastructure.IRepository
{
    public interface IProductRepository : IRepository<ProductModels>
    {
        void Update(ProductModels product);
    }
}
