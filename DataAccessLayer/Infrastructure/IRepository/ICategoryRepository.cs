using Models;

namespace DataAccessLayer.Infrastructure.IRepository
{
    public interface ICategoryRepository: IRepository<CategoryModels>
    {
        void Update(CategoryModels model);
    }
}
