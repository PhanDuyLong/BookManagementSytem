using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
using System;
using System.Collections.Generic;

namespace BookManagementSystemData.ViewModels.BorrowTicketViewModel
{
    public class BorrowTicketGetItems
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public int? TotalQuantity { get; set; }
        public DateTime? ReturnDeadline { get; set; }
        public bool? IsDone { get; set; }
        public string BorrowerId { get; set; }
        public string CreateName { get; set; }
        public string BorrowName { get; set; }
        public virtual ICollection<BorrowTicketDetailGetItems> BorrowTicketDetails { get; set; }
    }
}
