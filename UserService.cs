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

    public bool RegisterUser(string email, string username, string password) {
        // Check if the user already exists
        if (_context.Users.Any(u => u.Email == email || u.Username == username)) {
            return false; // User already exists
        }

        // Create a new user
        var user = new User {
            Email = email,
            Username = username,
            PasswordHash = HashPassword(password)
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