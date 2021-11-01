using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystemData.ViewModels.Book
{
    public class BookDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Status { get; set; }
        public string CategoryName { get; set; }
    }
}
