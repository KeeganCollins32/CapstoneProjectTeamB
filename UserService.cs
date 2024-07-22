using Capstone1;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public class UserService {
    private readonly MyDbContext _context;

    public UserService() {
        _context = new MyDbContext();
    }

    public bool RegisterUser(string email, string password, string firstName, string lastName, string phone, string role) {
        // Check if the user already exists based on email
        if (_context.Users.Any(u => u.Email == email)) {
            return false; // Email already exists
        }

        // Create a new user
        var user = new User {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Role = role,
            Password = HashPassword(password),
            IsActive = true,
            CreatedAt = DateTime.Now, // Set CreatedAt to the current date and time
            UpdatedAt = DateTime.Now // Set UpdatedAt to the current date and time
        };

        // Save the user to the database
        _context.Users.Add(user);
        _context.SaveChanges();

        return true;
    }

    private string HashPassword(string password) {
        using (var sha256 = SHA256.Create()) {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}