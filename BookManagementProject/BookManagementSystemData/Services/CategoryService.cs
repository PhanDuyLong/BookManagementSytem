using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(DbContext dbContext, ICategoryRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }
    }
}
