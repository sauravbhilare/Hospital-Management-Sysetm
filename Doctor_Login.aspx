<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Doctor_Login.aspx.cs" Inherits="Doctor_Login" %>

<!DOCTYPE html>
<html class="h-100" lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Doctor</title>
    <!-- Favicon icon -->
    <link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png">
    <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous"> -->
    <link href="css/style.css" rel="stylesheet">
</head>

<body class="h-100">

    <!--*******************
        Preloader start
    ********************-->
    <div id="preloader">
        <div class="loader">
            <svg class="circular" viewBox="25 25 50 50">
                <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="3" stroke-miterlimit="10" />
            </svg>
        </div>
    </div>
    <!--*******************
        Preloader end
    ********************-->
    <div class="login-form-bg h-100">
        <div class="container h-100">
            <div class="row justify-content-center h-100">
                <div class="col-xl-6">
                    <div class="form-input-content">
                        <div class="card login-form mb-0">
                            <div class="card-body pt-5">
                                <a class="text-center" href="#">
                                    <h2>LOGO</h2>
                                </a>

                                <form class="mt-5 mb-5 login-input" runat="server">
                                    <div class="form-group col-md-12">
                                        <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Username"
                                            ValidationGroup="valid" ControlToValidate="txtusername" InitialValue="" Display="None"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <asp:TextBox ID="txtpass" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password"
                                            ValidationGroup="valid" ControlToValidate="txtpass" InitialValue="" Display="None"></asp:RequiredFieldValidator>
                                    </div>
<%--                                    <div class="form-group col-md-12">
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlrole">
                                            <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Master Admin" Value="Master Admin"></asp:ListItem>
                                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                                            <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Select Role"
                                            ValidationGroup="valid" ControlToValidate="ddlrole" InitialValue="" Display="None"></asp:RequiredFieldValidator>
                                    </div>--%>
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Please enter/correct the following fields"
                                        ValidationGroup="valid" ShowMessageBox="true" ShowSummary="false" />
                                    <asp:Button ID="btnlogin" runat="server" CssClass="btn login-form__btn submit w-100" Text="Sign In" OnClick="btnlogin_Click" ValidationGroup="valid" />
                                </form>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <!--**********************************
        Scripts
    ***********************************-->
    <script src="plugins/common/common.min.js"></script>
    <script src="js/custom.min.js"></script>
    <script src="js/settings.js"></script>
    <script src="js/gleek.js"></script>
    <script src="js/styleSwitcher.js"></script>
</body>
</html>

