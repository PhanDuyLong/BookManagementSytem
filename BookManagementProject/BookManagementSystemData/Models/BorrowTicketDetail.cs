using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagementSystemData.Models
{
    public partial class BorrowTicketDetail
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? BorrowTicketId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool? IsReturned { get; set; }

        public virtual Book Book { get; set; }
        public virtual BorrowTicket BorrowTicket { get; set; }
    }
}
