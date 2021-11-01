/*using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.ViewModels.UserViewModel;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Services
{
    public interface IUserService : IBaseService<User>
    {
        public Task<UserGetItems> Login(string id, string pass);
        public Task<IList<UserGetItems>> GetAllUsers();
    }
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;

        public UserService(DbContext dbContext, IUserRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
            _userRepo = repository;
        }
        public async Task<IList<UserGetItems>> GetAllUsers()
        {
            var users = _userRepo.Get().ToList();
            if (users == null || users.Count() == 0)
            {
                return null;
            }

            IList<UserGetItems> listUser = new List<UserGetItems>();

            foreach (var item in users)
            {
                listUser.Add(_mapper.Map<UserGetItems>(item));
            }

            return listUser;
        }

        public async Task<UserGetItems> Login(string id, string pass)
        {
            var user = _userRepo.FirstOrDefault(u => (u.Username == id && u.Password == pass));
            if (user == null)
            {
                return null;
            }
            UserGetItems result = _mapper.Map<UserGetItems>(user);

            return result;
        }

    }
}
*/