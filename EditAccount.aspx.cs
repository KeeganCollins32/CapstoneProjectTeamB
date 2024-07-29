using System;
using System.Web.UI;
using MySql.Data.MySqlClient;

namespace Capstone1 {
    public partial class EditAccount : BasePage {
        private string connectionString = "Server=38.242.202.171;Port=30000;Database=Dent_Repair;Uid=root;Pwd=root;";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                PopulateUserProfile();
            }
        }

        private void PopulateUserProfile() {
            if (Session["UserID"] != null) {
                int userId = Convert.ToInt32(Session["UserID"]);

                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    string query = "SELECT FirstName, LastName, Email, PhoneNumber, Address, ProfilePicture FROM users WHERE UserID = @UserID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userId);

                    try {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read()) {
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            Email.Text = reader["Email"].ToString();
                            PhoneNumber.Text = reader["PhoneNumber"].ToString();
                            Address.Text = reader["Address"].ToString();
                            string profileImage = reader["ProfilePicture"].ToString();

                            // Set user's full name
                            UserNameLabel.Text = $"{firstName} {lastName}";

                            // Set profile image
                            if (!string.IsNullOrEmpty(profileImage)) {
                                ProfileImage.ImageUrl = profileImage;
                            }
                            else {
                                ProfileImage.ImageUrl = "https://picsum.photos/200/200";
                            }

                            // Populate text fields with user data
                            FirstName.Text = firstName;
                            LastName.Text = lastName;
                        }
                    }
                    catch (Exception ex) {
                        // Handle exceptions
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e) {
            if (Session["UserID"] != null) {
                int userId = Convert.ToInt32(Session["UserID"]);

                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    string query = "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address WHERE UserID = @UserID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", FirstName.Text);
                    command.Parameters.AddWithValue("@LastName", LastName.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text);
                    command.Parameters.AddWithValue("@Address", Address.Text);
                    command.Parameters.AddWithValue("@UserID", userId);

                    try {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        // Handle exceptions
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        protected void EditImageLink_Click(object sender, EventArgs e) {
            // Logic for editing image
        }
    }
}