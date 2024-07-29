using System;
using System.Linq;

namespace Capstone1 {
    public class UserService {
        private readonly MyDbContext _context;

        public UserService() {
            _context = new MyDbContext();
        }

        public bool RegisterUser(string firstName, string lastName, string email, string password, string phoneNumber, string address, string userType) {
            // Check if the user already exists based on email
            if (_context.Users.Any(u => u.Email == email)) {
                return false; // Email already exists
            }

            // Create a new user
            var user = new User {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                UserType = userType,
                Password = password, 
                CreatedAt = DateTime.Now, 
            };

            // Save the user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }
    }
}