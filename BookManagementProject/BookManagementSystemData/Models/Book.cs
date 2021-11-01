using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagementSystemData.Models
{
    public partial class Book
    {
        public Book()
        {
            BorrowTicketDetails = new HashSet<BorrowTicketDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<BorrowTicketDetail> BorrowTicketDetails { get; set; }
    }
}
