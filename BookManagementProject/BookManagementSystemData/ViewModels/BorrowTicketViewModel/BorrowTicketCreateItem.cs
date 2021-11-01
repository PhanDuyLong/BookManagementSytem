using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystemData.ViewModels.BorrowTicketViewModel
{
    public class BorrowTicketCreateItem
    {
        public string CreatorId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public int? TotalQuantity { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public bool? IsDone { get; set; }
        public string BorrowerId { get; set; }
    }
}
