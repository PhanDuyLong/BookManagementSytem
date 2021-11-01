using BookManagementSystemData.Models;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookManagementSystemData.Repositories
{
    public interface IBorrowTicketDetailRepository : IBaseRepository<BorrowTicketDetail>
    {
        public bool isTicketDetailExists(int id);
    }
    public class BorrowTicketDetailRepository : BaseRepository<BorrowTicketDetail>, IBorrowTicketDetailRepository
    {
        public BorrowTicketDetailRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public bool isTicketDetailExists(int id)
        {
            return _dbSet.Any(e => e.Id.Equals(id));
        }
    }
}
