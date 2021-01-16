using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntranceExamServer.Models
{
    class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
        public bool isActive { get; set; }
    }

    enum UserRole 
    {
        ADMIN = 1,
        STAFF = 2
    }
}
