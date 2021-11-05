using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookManagementSystemData.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<List<Category>> GetCategoriesAsync();
    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(DbContext dbContext, ICategoryRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var category = await Get().ToListAsync();

            return category;
        }
    }
}
