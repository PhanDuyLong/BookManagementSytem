using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagementSystemData.Models
{
    public partial class BorrowTicket
    {
        public BorrowTicket()
        {
            BorrowTicketDetails = new HashSet<BorrowTicketDetail>();
        }

        public int Id { get; set; }
        public string CreatorId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public int? TotalQuantity { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public bool? IsDone { get; set; }
        public string BorrowerId { get; set; }
        public virtual User Borrower { get; set; }
        public virtual User Creator { get; set; }
        public virtual ICollection<BorrowTicketDetail> BorrowTicketDetails { get; set; }
    }
}
