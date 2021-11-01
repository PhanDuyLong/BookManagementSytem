/*using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Services
{
    public interface IBorrowTicketService : IBaseService<BorrowTicket>
    {
    }
    public class BorrowTicketService : BaseService<BorrowTicket>, IBorrowTicketService
    {
        private readonly IMapper _mapper;
        public BorrowTicketService(DbContext dbContext, IBorrowTicketRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
        }
    }
}
*/