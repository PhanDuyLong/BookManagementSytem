/*using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Services
{
    public interface IUserService : IBaseService<User>
    {
    }
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(DbContext dbContext, IUserRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }
    }
}
*/