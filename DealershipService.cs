using System;
using System.Linq;

namespace Capstone1 {
    public class DealershipService {
        private readonly MyDbContext _context;

        public DealershipService() {
            _context = new MyDbContext();
        }

        public bool CreateDealership(string dealershipName, string dealershipBrand, string email, string password, string phoneNumber, string address, string userType) {
            // Check if the dealership already exists based on email
            if (_context.Users.Any(u => u.Email == email)) {
                return false; // Email already exists
            }

            // Create a new dealership
            var dealership = new User {
                FirstName = dealershipName,  // Dealership Name
                LastName = dealershipBrand,  // Dealership Brand
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                UserType = userType, 
                Password = password, 
                CreatedAt = DateTime.Now, 
            };

            // Save the dealership to the database
            _context.Users.Add(dealership);
            _context.SaveChanges();

            return true;
        }
    }
}