using BookManagementSystemData.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Parameters
{
    public class BookParameters : QueryStringParameters
    {
        public string SearchInput { get; set; }
    }
}
