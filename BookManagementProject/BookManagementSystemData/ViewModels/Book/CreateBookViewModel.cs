using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystemData.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
