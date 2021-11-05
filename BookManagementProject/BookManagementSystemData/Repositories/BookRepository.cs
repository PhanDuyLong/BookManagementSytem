using BookManagementSystemData.Models;
using BookManagementSystemData.Parameters;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        IQueryable<Book> FindBooksAsync(BookParameters bookParameters);
    }
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly DbContext _dbContext;
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Book> FindBooksAsync(BookParameters bookParameters)
        {
            var books = Get(b => b.Status != "Deleted");

            SearchByNameCategoryAndAuthor(ref books, bookParameters.SearchInput);

            //foreach (var book in books)
            //{
            //    _dbContext.Entry(book)
            //        .Reference(b => b.Category)
            //        .Query()
            //        .Load();
            //}

            return books;
        }

        private void SearchByNameCategoryAndAuthor(ref IQueryable<Book> books, string searchInput)
        {
            if (!books.Any() || string.IsNullOrWhiteSpace(searchInput))
                return;

            books = books.Include(b => b.Category).Where(c => c.Name.ToLower().Contains(searchInput.Trim().ToLower())
            || c.Category.Name.ToLower().Contains(searchInput.Trim().ToLower())
            || c.Author.ToLower().Contains(searchInput.Trim().ToLower()));
        }
    }
}
