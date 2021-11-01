using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystemData.ViewModels.BorrowTicketDetailModel
{
    public class BorrowTicketDetailUpdateItem
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? BorrowTicketId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool? IsReturned { get; set; }
    }
}
