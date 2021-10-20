using BookManagementSystemData.Models;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
