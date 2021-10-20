using System;
using System.Collections.Generic;

#nullable disable

namespace BookManagementSystemData.Models
{
    public partial class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
