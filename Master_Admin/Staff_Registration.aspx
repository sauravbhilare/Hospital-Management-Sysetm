<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Staff_Registration.aspx.cs" Inherits="Master_Admin_Staff_Registration" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        /* CSS style to add margin between checkbox and text */
        .form-check input[type="checkbox"] {
            margin-right: 15px; /* Adjust the value to your preference */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="mastername" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblstaffid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="pancard" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="photo" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpass" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <div class="row page-titles mx-0">
        <div class="col p-md-0">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="javascript:void(0)">Dashboard</a></li>
                <li class="breadcrumb-item active"><a href="javascript:void(0)">Home</a></li>
            </ol>
        </div>
    </div>
    <!-- row -->

    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h4 class="card-title">Staff Registration</h4>

                        <form>
                            <div class="basic-form">
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>First Name <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtfname" runat="server" class="form-control" placeholder="First Name" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Middle Name</label>
                                        <asp:TextBox ID="txtmname" runat="server" class="form-control" placeholder="Middle Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Last Name <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtlname" runat="server" class="form-control" placeholder="Last Name" required></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <label>Gender</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlgender">
                                            <asp:ListItem Text="Choose Gender" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>DOB</label>
                                        <asp:TextBox ID="txtdob" runat="server" class="form-control" placeholder="" TextMode="date" oninput="reflectValue()"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Mobile <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Mobile" required oninput="reflectValue()"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Alternate Mobile</label>
                                        <asp:TextBox ID="txtaltmobile" runat="server" class="form-control" placeholder="Alternate Mobile"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Gmail</label>
                                        <asp:TextBox ID="txtgmail" runat="server" class="form-control" placeholder="Gmail"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Role <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlrole" required>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Department <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddldepartment" required>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Qualification <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtqualification" runat="server" class="form-control" placeholder="Qualification" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Pan No <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtpanno" runat="server" class="form-control" placeholder="Pan No" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Pan Card <span style="color: red">*</span></label>
                                        <asp:FileUpload ID="panfile" runat="server" class="form-control" />
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Photo</label>
                                        <asp:FileUpload ID="filephoto" runat="server" class="form-control" />
                                    </div>


                                </div>
                            </div>
                            <asp:UpdatePanel ID="up1" runat="server">
                                <ContentTemplate>
                                    <div class="basic-form">
                                        <h5 class="fs-title">Account Details</h5>
                                        <div class="form-row">

                                            <div class="form-check col-md-12" id="chkbx" runat="server" visible="false">
                                                <asp:CheckBox ID="chkupdate" runat="server" CssClass="" Text="Update Username And Password" OnCheckedChanged="ChckedChanged" AutoPostBack="true" />
                                            </div>

                                            <div class="form-group col-md-4" id="divuser" runat="server">
                                                <label>Username</label>
                                                <asp:TextBox ID="txtusername" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
                                            </div>


                                            <div class="form-group col-md-4" id="divpass" runat="server">
                                                <label>Password <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtpassword" runat="server" class="form-control" placeholder="Password" TextMode="password" required></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4" id="divcpass" runat="server">
                                                <label>Confirm Password <span style="color: red">*</span></label>
                                                <asp:TextBox ID="cnpass" runat="server" class="form-control" placeholder="Confirm Password" TextMode="password" required oninput="validatePasswords()"></asp:TextBox>
                                                <span id="passwordMatchMessage" style="color: red; display: none;">Passwords do not match.</span>
                                            </div>


                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_OnClick" />
                                    </center>

                        </form>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        // JavaScript function to check if passwords match
        function validatePasswords() {
            var password = document.getElementById('<%= txtpassword.ClientID %>').value;
            var confirmPassword = document.getElementById('<%= cnpass.ClientID %>').value;
            var message = document.getElementById('passwordMatchMessage');

            if (confirmPassword === '') {
                message.style.display = 'none'; // Hide the error message if confirm password is blank
            } else if (password === confirmPassword) {
                message.style.display = 'none'; // Hide the error message if passwords match
            } else {
                message.style.display = 'block'; // Show the error message if passwords don't match
            }
        }
        function reflectValue() {
            var firstTextboxValue = document.getElementById('<%= txtmobile.ClientID %>').value;
            document.getElementById('<%= txtusername.ClientID %>').value = firstTextboxValue;
        }
    </script>
</asp:Content>

