using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone1 {
    public class User {
        public int Id { get; set; } // Primary key
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords
    }
}