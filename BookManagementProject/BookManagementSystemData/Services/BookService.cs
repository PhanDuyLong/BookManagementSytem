using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Services
{
    public interface IBookService : IBaseService<Book>
    {
    }
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IMapper _mapper;
        public BookService(DbContext dbContext, IBookRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }
    }
}
