using System;
using System.Diagnostics;
using System.Linq;
using Capstone1;
using MySql.Data.MySqlClient;

namespace Capstone1 {
	public partial class SignUp : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Any necessary code for Page Load
        }

        protected void SignUpButton_Click(object sender, EventArgs e) {
            string username = UserName.Text;
            string email = Email.Text;
            string password = Password.Text;

            if (IsValid) {
                ErrorMessageUsername.Text = "";
                ErrorMessageEmail.Text = "";
                ErrorMessage.Text = "";

                try {
                    using (var context = new MyDbContext()) {
                        // Log the beginning of the query execution
                        Console.WriteLine("Starting user existence check...");

                        // Measure query execution time
                        var stopwatch = Stopwatch.StartNew();

                        // Check if username or email already exists
                        bool userExists = context.Users.Any(u => u.Username == username || u.Email == email);

                        // Log the time taken for the query
                        stopwatch.Stop();
                        Console.WriteLine($"Query executed in: {stopwatch.ElapsedMilliseconds} ms");

                        // Check and handle user existence
                        if (userExists) {
                            if (context.Users.Any(u => u.Username == username)) {
                                ErrorMessageUsername.Text = "Username already exists";
                            }
                            if (context.Users.Any(u => u.Email == email)) {
                                ErrorMessageEmail.Text = "Email already exists";
                            }
                        }
                        else {
                            // Create a new user
                            var user = new User {
                                Username = username,
                                Email = email,
                                PasswordHash = HashPassword(password)
                            };

                            context.Users.Add(user);
                            context.SaveChanges();

                            // Optionally, handle success (redirect to success page)
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
                catch (Exception ex) {
                    // Handle exception (display error message)
                    ErrorMessage.Text = "An error occurred while signing up. Please try again later.";
                    // Optionally, log the exception for debugging purposes
                    Console.WriteLine("Exception: " + ex.Message);
                    if (ex.InnerException != null) {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }
                }
            }
        }

        private string HashPassword(string password) {
            using (var sha256 = System.Security.Cryptography.SHA256.Create()) {
                var bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}