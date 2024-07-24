<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="Capstone1.EditAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
		function triggerFilePicker() {
			document.getElementById('filePicker').click();
		}

		function uploadImage() {
			var fileInput = document.getElementById('filePicker');
			var file = fileInput.files[0];

			if (file) {
				var formData = new FormData();
				formData.append('profileImage', file);

				var xhr = new XMLHttpRequest();
				xhr.open('POST', 'UploadImageHandler.ashx', true);
				xhr.onload = function () {
					if (xhr.status === 200) {
						// Update profile image URL
						document.getElementById('<%= ProfileImage.ClientID %>').src = xhr.responseText;
					} else {
						alert('Failed to upload image.');
					}
				};
				xhr.send(formData);
			}
		}
</script>
    <style>
        .contentProfile {
            padding: 20px;
            margin-top: 60px;
            background-color: #fff;
            margin: 20px auto;
            max-width: 1200px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            flex: 1;
        }

        .profile-container {
            padding: 20px;
            background-color: #fff;
            margin: 60px auto;
            max-width: 1000px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .image-container {
            position: relative;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .edit-image-overlay {
            position: absolute;
            bottom: -10px;
            right: -10px;
            background-color: rgba(0, 0, 0, 0.5);
            color: #fff;
            padding: 5px;
            cursor: pointer;
            border-radius: 50%;
            transform: translate(50%, 50%);
            width: 30px;
            height: 30px;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 20px;
            font-family: Arial, sans-serif;
        }

        .profile-image {
            width: 150px;
            height: 150px;
            border-radius: 50%;
            object-fit: cover;
            border: 2px solid #ddd;
            background-color: #f5f5f5;
            position: relative;
        }

        .default-image {
            background-color: #333; /* Default circle color */
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .default-image::before {
            content: "\f007"; /* Unicode for a user outline icon */
            font-family: FontAwesome; /* Ensure FontAwesome is included in your project */
            color: #fff;
            font-size: 50px;
        }

        .profile-info {
            text-align: center;
            display: flex;
            flex-direction: column;
            width: 100%;
        }

        .profile-info h2 {
            font-size: 24px;
            font-weight: bold;
            color: #333;
            margin-bottom: 10px;
            text-align: center;
        }

        .profile-info p {
            font-size: 18px;
            color: #333;
            margin-bottom: 10px;
            text-align: center;
        }

        .form-group {
            margin-bottom: 15px;
            width: 50%;
        }

        .form-group label {
            display: block;
            color: #555;
            margin-bottom: 5px;
        }

        .form-control {
            width: 100%;
            padding: 8px;
            font-size: 14px;
        }

        .button-primary {
            display: block;
            width: fit-content;
            margin: 20px 0;
            padding: 10px 20px;
            background-color: #ff6347;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            text-align: center;
        }

        .button-primary:hover {
            background-color: #e5533a;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contentProfile">
        <div class="profile-container">
            <div class="image-container">
                <asp:Image ID="ProfileImage" runat="server" CssClass="profile-image" ImageUrl="https://picsum.photos/200/200" />
                <asp:LinkButton ID="EditImageLink" runat="server" CssClass="edit-image-overlay" Text="✎" OnClientClick="triggerFilePicker(); return false;" />
            </div>
            <div class="profile-info">
                <asp:Label ID="UserNameLabel" runat="server" Text="User's Name" CssClass="form-label" />
                <h2>Edit Profile</h2>
            </div>
            <div class="form-group">
                <label for="FirstName">First Name</label>
                <asp:TextBox ID="FirstName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="LastName">Last Name</label>
                <asp:TextBox ID="LastName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Email">Email</label>
                <asp:TextBox ID="Email" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="PhoneNumber">Phone Number</label>
                <asp:TextBox ID="PhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update Profile" CssClass="button-primary" OnClick="ButtonUpdate_Click" />
            </div>
        </div>
    </div>
    <!-- Hidden file input -->
    <input type="file" id="filePicker" style="display: none;" onchange="uploadImage()" />
</asp:Content>