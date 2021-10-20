using BookManagementSystemData.Models;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookManagementSystemData.Repositories
{
    public interface IBorrowTicketDetailRepository : IBaseRepository<BorrowTicketDetail>
    {
    }
    public class BorrowTicketDetailRepository : BaseRepository<BorrowTicketDetail>, IBorrowTicketDetailRepository
    {
        public BorrowTicketDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
