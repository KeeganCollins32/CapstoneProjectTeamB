using System;

namespace Capstone1 {
    public class User {
        public int Id { get; set; } // Matches 'UserID'
        public string FirstName { get; set; } // Matches 'FirstName'
        public string LastName { get; set; } // Matches 'LastName'
        public string Email { get; set; } // Matches 'Email'
        public string PhoneNumber { get; set; } // Matches 'PhoneNumber'
        public string Address { get; set; } // Matches 'Address'
        public string Password { get; set; } // Matches 'Password'
        public string UserType { get; set; } // Matches 'UserType' and should use enum('Client','Dealership','Technician')
        public string ProfilePicture { get; set; } // Matches 'ProfilePicture', nullable
        public DateTime CreatedAt { get; set; } // Matches 'CreatedAt'
        public DateTime? UpdatedAt { get; set; } // Matches 'UpdatedAt', nullable
    }
}
