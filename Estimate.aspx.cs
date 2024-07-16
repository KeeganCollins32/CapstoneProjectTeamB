using System;
using System.Web.UI;

namespace Capstone1 {
    public partial class Estimate : Page {
        protected void Page_Load(object sender, EventArgs e) {
            // Any page initialization code here
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            // Handle form submission
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = Email.Text;
            string phoneNumber = PhoneNumber.Text;
            string vehicleBrand = VehicleBrand.SelectedValue;
            string vehicleModel = VehicleModel.SelectedValue;
            string vehicleYear = VehicleYear.SelectedValue;
            string message = Message.Text;
            bool acceptTerms = AcceptTerms.Checked;

            // Add your logic to process the form data here

            // Handle file upload
            if (FileUpload.HasFile) {
                string fileName = FileUpload.FileName;
                // Save the file or perform further processing
            }

            // Provide feedback to the user, e.g., show a success message
        }

        protected void UploadImageButton_Click(object sender, EventArgs e) {
            // Handle the logic for uploading the image here
            // Example: Save the uploaded file, process it, etc.
            // For example purposes, you can check if a file was uploaded
            if (FileUpload.HasFile) {
                // Get the file details
                string fileName = FileUpload.FileName;
                string filePath = Server.MapPath("~/Uploads/") + fileName;

                // Save the file
                FileUpload.SaveAs(filePath);

                // Optionally, you can store the file path in a database or perform further processing
                // Example: Save file path to database
                // SaveFilePathToDatabase(filePath);

                // Provide feedback to the user (optional)
                // Response.Write("File uploaded successfully!");
            }
            else {
                // Handle case where no file was uploaded
                // Response.Write("Please select a file to upload!");
            }

            // Redirect or display a thank you message as needed
            Response.Redirect("~/ThankYouPage.aspx"); // Example redirection after submission
        }
    }
}
