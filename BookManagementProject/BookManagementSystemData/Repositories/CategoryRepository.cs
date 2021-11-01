using BookManagementSystemData.Models;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
