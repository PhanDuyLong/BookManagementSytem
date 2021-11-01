/*using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Services
{
    public interface IBorrowTicketDetailService : IBaseService<BorrowTicketDetail>
    {
    }
    public class BorrowTicketDetailService : BaseService<BorrowTicketDetail>, IBorrowTicketDetailService
    {
        private readonly IMapper _mapper;
        public BorrowTicketDetailService(DbContext dbContext, IBorrowTicketDetailRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }
    }
}
*/