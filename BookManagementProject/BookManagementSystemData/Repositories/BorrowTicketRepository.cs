using BookManagementSystemData.Models;
using HMS.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookManagementSystemData.Repositories
{
    public interface IBorrowTicketRepository : IBaseRepository<BorrowTicket>
    {
        public bool isTicketExists(int id);
    }
    public class BorrowTicketRepository : BaseRepository<BorrowTicket>, IBorrowTicketRepository
    {
        public BorrowTicketRepository(DbContext dbContext) : base(dbContext)
        {
            
        }
        public bool isTicketExists(int id)
        {
            return _dbSet.Any(e => e.Id.Equals(id));
        }
    }
}
