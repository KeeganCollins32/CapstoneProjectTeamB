using System;
using System.IO;
using System.Web;

namespace Capstone1 {
    public class UploadImageHandler : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            if (context.Request.Files.Count > 0) {
                HttpPostedFile file = context.Request.Files[0];
                string fileName = Path.GetFileName(file.FileName);
                string uploadPath = context.Server.MapPath("~/Uploads/");

                // Ensure the upload directory exists
                if (!Directory.Exists(uploadPath)) {
                    Directory.CreateDirectory(uploadPath);
                }

                string filePath = Path.Combine(uploadPath, fileName);
                file.SaveAs(filePath);

                // Respond with the URL of the uploaded image
                context.Response.ContentType = "text/plain";
                context.Response.Write("~/Uploads/" + fileName);
            }
            else {
                context.Response.StatusCode = 400;
                context.Response.Write("No file uploaded.");
            }
        }

        public bool IsReusable {
            get { return false; }
        }
    }
}