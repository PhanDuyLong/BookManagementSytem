using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystemData.ViewModels.BorrowTicketDetailModel
{
    public class BorrowTicketDetailCreateItem
    {
        public int? BookId { get; set; }
        public bool? IsReturned { get; set; }
        
    }
}
