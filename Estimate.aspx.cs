using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Capstone1 {
    public partial class Estimate : Page {
        private string connectionString = "Server=38.242.202.171;Port=30000;Database=Dent_Repair;Uid=root;Pwd=root;";

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                PopulateVehicleDropdowns();
                PopulateUserProfile();
            }
        }

        private void PopulateVehicleDropdowns() {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                conn.Open();

                // Populate Vehicle Brand dropdown
                string query = "SELECT VehicleBrandID, VehicleBrand FROM vehiclebrand";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                VehicleBrandDropDown.DataSource = reader;
                VehicleBrandDropDown.DataTextField = "VehicleBrand";
                VehicleBrandDropDown.DataValueField = "VehicleBrandID";
                VehicleBrandDropDown.DataBind();
                VehicleBrandDropDown.Items.Insert(0, new ListItem("Select Brand", ""));
                reader.Close();

                // Populate Vehicle Year dropdown
                query = "SELECT VehicleYear FROM vehicleyear ORDER BY VehicleYear DESC";
                cmd.CommandText = query;
                reader = cmd.ExecuteReader();
                VehicleYearDropDown.DataSource = reader;
                VehicleYearDropDown.DataTextField = "VehicleYear";
                VehicleYearDropDown.DataValueField = "VehicleYear";
                VehicleYearDropDown.DataBind();
                VehicleYearDropDown.Items.Insert(0, new ListItem("Select Year", ""));
                reader.Close();
            }
        }

        private void PopulateUserProfile() {
            if (Session["UserID"] != null) {
                int userId = Convert.ToInt32(Session["UserID"]);

                using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                    string query = "SELECT FirstName, LastName, Email, PhoneNumber, ProfilePicture FROM users WHERE UserID = @UserID";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", userId);

                    try {
                        connection.Open();
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read()) {
                            FirstNameTextBox.Text = reader["FirstName"].ToString();
                            LastNameTextBox.Text = reader["LastName"].ToString();
                            EmailTextBox.Text = reader["Email"].ToString();
                            PhoneNumberTextBox.Text = reader["PhoneNumber"].ToString();
                        }
                        reader.Close();
                    }
                    catch (Exception ex) {
                        // Handle exceptions
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        protected void VehicleBrandDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            int selectedBrandId;
            if (int.TryParse(VehicleBrandDropDown.SelectedValue, out selectedBrandId)) {
                PopulateVehicleModels(selectedBrandId);
            }
        }

        private void PopulateVehicleModels(int brandId) {
            using (MySqlConnection conn = new MySqlConnection(connectionString)) {
                conn.Open();

                // Populate Vehicle Model dropdown based on selected brand
                string query = "SELECT VehicleModelID, VehicleModel FROM vehiclemodel WHERE VehicleBrandID = @VehicleBrandID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehicleBrandID", brandId);
                MySqlDataReader reader = cmd.ExecuteReader();
                VehicleModelDropDown.DataSource = reader;
                VehicleModelDropDown.DataTextField = "VehicleModel";
                VehicleModelDropDown.DataValueField = "VehicleModelID";
                VehicleModelDropDown.DataBind();
                VehicleModelDropDown.Items.Insert(0, new ListItem("Select Model", ""));
                reader.Close();
            }
        }

        protected void VehicleModelDropDown_SelectedIndexChanged(object sender, EventArgs e) {
            // Handle vehicle model change if needed
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            // Handle form submission
        }

        protected void UploadImageButton_Click(object sender, EventArgs e) {
            // Handle image upload
        }
    }
}