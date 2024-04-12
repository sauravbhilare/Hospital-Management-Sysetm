<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Patient_Registration" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Doctor</title>
    <!-- Favicon icon -->
    <link rel="icon" type="../image/png" sizes="16x16" href="../images/favicon.png">
    <!-- Custom Stylesheet -->
    <link href="../css/style.css" rel="stylesheet">
</head>

<body>
    <asp:Label ID="lblid" Visible="false" runat="server"></asp:Label>
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


    <!--**********************************
        Main wrapper start
    ***********************************-->
    <div id="main-wrapper">

        <!--**********************************
            Nav header start
        ***********************************-->
        <div class="nav-header">
            <div class="brand-logo">
                <a href="index.html">
                    <b class="logo-abbr">
                        <img src="../images/logo.png" alt="">
                    </b>
                    <span class="logo-compact">
                        <img src="../images/logo-compact.png" alt=""></span>
                    <span class="brand-title">
                        <img src="../images/logo-text.png" alt="">
                    </span>
                </a>
            </div>
        </div>
        <!--**********************************
            Nav header end
        ***********************************-->

        <!--**********************************
            Header start
        ***********************************-->
        <div class="header">
            <div class="header-content clearfix">

                <div class="nav-control">
                    <div class="hamburger">
                        <span class="toggle-icon"><i class="icon-menu"></i></span>
                    </div>
                </div>

                <div class="header-right">
                    <ul class="clearfix">



                        <li class="icons dropdown">
                            <div class="user-img c-pointer position-relative" data-toggle="dropdown">
                                <span class="activity active"></span>
                                <img src="../images/user/1.png" height="40" width="40" alt="">
                            </div>
                            <div class="drop-down dropdown-profile   dropdown-menu">
                                <div class="dropdown-content-body">
                                    <ul>
                                       <%-- <li>
                                            <a href="app-profile.html"><i class="icon-user"></i><span>Profile</span></a>
                                        </li>


                                        <hr class="my-2">--%>

                                        <li><a href="../Patient_Login.aspx"><i class="icon-key"></i><span>Go To Login</span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <!--**********************************
            Header end ti-comment-alt
        ***********************************-->

        <!--**********************************
            Sidebar start
        ***********************************-->
        <%--   <div class="nk-sidebar">           
            <div class="nk-nav-scroll">
                <ul class="metismenu" id="menu">
                    <li class="nav-label">Dashboard</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-speedometer menu-icon"></i><span class="nav-text">Dashboard</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./index.html">Home 1</a></li>
                            <!-- <li><a href="./index-2.html">Home 2</a></li> -->
                        </ul>
                    </li>
                    <li class="mega-menu mega-menu-sm">
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-globe-alt menu-icon"></i><span class="nav-text">Layouts</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./layout-blank.html">Blank</a></li>
                            <li><a href="./layout-one-column.html">One Column</a></li>
                            <li><a href="./layout-two-column.html">Two column</a></li>
                            <li><a href="./layout-compact-nav.html">Compact Nav</a></li>
                            <li><a href="./layout-vertical.html">Vertical</a></li>
                            <li><a href="./layout-horizontal.html">Horizontal</a></li>
                            <li><a href="./layout-boxed.html">Boxed</a></li>
                            <li><a href="./layout-wide.html">Wide</a></li>
                            
                            
                            <li><a href="./layout-fixed-header.html">Fixed Header</a></li>
                            <li><a href="layout-fixed-sidebar.html">Fixed Sidebar</a></li>
                        </ul>
                    </li>
                    <li class="nav-label">Apps</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-envelope menu-icon"></i> <span class="nav-text">Email</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./email-inbox.html">Inbox</a></li>
                            <li><a href="./email-read.html">Read</a></li>
                            <li><a href="./email-compose.html">Compose</a></li>
                        </ul>
                    </li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-screen-tablet menu-icon"></i><span class="nav-text">Apps</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./app-profile.html">Profile</a></li>
                            <li><a href="./app-calender.html">Calender</a></li>
                        </ul>
                    </li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-graph menu-icon"></i> <span class="nav-text">Charts</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./chart-flot.html">Flot</a></li>
                            <li><a href="./chart-morris.html">Morris</a></li>
                            <li><a href="./chart-chartjs.html">Chartjs</a></li>
                            <li><a href="./chart-chartist.html">Chartist</a></li>
                            <li><a href="./chart-sparkline.html">Sparkline</a></li>
                            <li><a href="./chart-peity.html">Peity</a></li>
                        </ul>
                    </li>
                    <li class="nav-label">UI Components</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-grid menu-icon"></i><span class="nav-text">UI Components</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./ui-accordion.html">Accordion</a></li>
                            <li><a href="./ui-alert.html">Alert</a></li>
                            <li><a href="./ui-badge.html">Badge</a></li>
                            <li><a href="./ui-button.html">Button</a></li>
                            <li><a href="./ui-button-group.html">Button Group</a></li>
                            <li><a href="./ui-cards.html">Cards</a></li>
                            <li><a href="./ui-carousel.html">Carousel</a></li>
                            <li><a href="./ui-dropdown.html">Dropdown</a></li>
                            <li><a href="./ui-list-group.html">List Group</a></li>
                            <li><a href="./ui-media-object.html">Media Object</a></li>
                            <li><a href="./ui-modal.html">Modal</a></li>
                            <li><a href="./ui-pagination.html">Pagination</a></li>
                            <li><a href="./ui-popover.html">Popover</a></li>
                            <li><a href="./ui-progressbar.html">Progressbar</a></li>
                            <li><a href="./ui-tab.html">Tab</a></li>
                            <li><a href="./ui-typography.html">Typography</a></li>
                        <!-- </ul>
                    </li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-layers menu-icon"></i><span class="nav-text">Components</span>
                        </a>
                        <ul aria-expanded="false"> -->
                            <li><a href="./uc-nestedable.html">Nestedable</a></li>
                            <li><a href="./uc-noui-slider.html">Noui Slider</a></li>
                            <li><a href="./uc-sweetalert.html">Sweet Alert</a></li>
                            <li><a href="./uc-toastr.html">Toastr</a></li>
                        </ul>
                    </li>
                    <li>
                        <a href="widgets.html" aria-expanded="false">
                            <i class="icon-badge menu-icon"></i><span class="nav-text">Widget</span>
                        </a>
                    </li>
                    <li class="nav-label">Forms</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-note menu-icon"></i><span class="nav-text">Forms</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./form-basic.html">Basic Form</a></li>
                            <li><a href="./form-validation.html">Form Validation</a></li>
                            <li><a href="./form-step.html">Step Form</a></li>
                            <li><a href="./form-editor.html">Editor</a></li>
                            <li><a href="./form-picker.html">Picker</a></li>
                        </ul>
                    </li>
                    <li class="nav-label">Table</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-menu menu-icon"></i><span class="nav-text">Table</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./table-basic.html" aria-expanded="false">Basic Table</a></li>
                            <li><a href="./table-datatable.html" aria-expanded="false">Data Table</a></li>
                        </ul>
                    </li>
                    <li class="nav-label">Pages</li>
                    <li>
                        <a class="has-arrow" href="javascript:void()" aria-expanded="false">
                            <i class="icon-notebook menu-icon"></i><span class="nav-text">Pages</span>
                        </a>
                        <ul aria-expanded="false">
                            <li><a href="./page-login.html">Login</a></li>
                            <li><a href="./page-register.html">Register</a></li>
                            <li><a href="./page-lock.html">Lock Screen</a></li>
                            <li><a class="has-arrow" href="javascript:void()" aria-expanded="false">Error</a>
                                <ul aria-expanded="false">
                                    <li><a href="./page-error-404.html">Error 404</a></li>
                                    <li><a href="./page-error-403.html">Error 403</a></li>
                                    <li><a href="./page-error-400.html">Error 400</a></li>
                                    <li><a href="./page-error-500.html">Error 500</a></li>
                                    <li><a href="./page-error-503.html">Error 503</a></li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
        </div>--%>
        <!--**********************************
            Sidebar end
        ***********************************-->

        <!--**********************************
            Content body start
        ***********************************-->



        <!-- row -->

        <asp:Label ID="lblstaffid" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblname" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblpatientid" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblprecript" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblreport" runat="server" Visible="false"></asp:Label>
        <div class="container-fluid">
            <div class="row justify-content-center">
                <div class="col-lg-12">
                    <div class="card" style="margin-top:15px;">
                        <div class="card-body">
                            <h3 class="card-title">Registration</h3>
                            <form id="form" runat="server">
                                <div class="basic-form">
                                    <h5 class="fs-title">Personal Details</h5>

                                    <div class="form-row">
                                        <div class="form-group col-md-3">
                                            <label>First Name <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtfname" runat="server" class="form-control" placeholder="First Name" required></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Middle Name</label>
                                            <asp:TextBox ID="txtmname" runat="server" class="form-control" placeholder="Middle Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Last Name <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtlname" runat="server" class="form-control" placeholder="Last Name" required></asp:TextBox>
                                        </div>

                                        <div class="form-group col-md-3">
                                            <label>Gender</label>
                                            <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlgender">
                                                <asp:ListItem Text="Choose Gender" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>DOB</label>
                                            <asp:TextBox ID="txtdob" runat="server" class="form-control" placeholder="" TextMode="date" onchange="calculateAge()"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Age</label>
                                            <asp:TextBox ID="txtage" runat="server" class="form-control" placeholder="Age"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Mobile <span style="color: red">*</span></label>
                                            <asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Mobile" required></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Alternate Mobile</label>
                                            <asp:TextBox ID="txtaltmobile" runat="server" class="form-control" placeholder="Alternate Mobile"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Gmail</label>
                                            <asp:TextBox ID="txtgmail" runat="server" class="form-control" placeholder="Gmail"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-9">
                                            <label>Address</label>
                                            <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="basic-form">
                                    <h5 class="fs-title">Emergency Contact</h5>
                                    <div class="form-row">
                                        <div class="form-group col-md-3">
                                            <label>Fisrt Name</label>
                                            <asp:TextBox ID="txtefname" runat="server" class="form-control" placeholder="Fisrt Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Last Name</label>
                                            <asp:TextBox ID="txtelname" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Relation</label>
                                            <asp:TextBox ID="txtrelationship" runat="server" class="form-control" placeholder="Relation"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Mobile </label>
                                            <asp:TextBox ID="txtemobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Family Doctor Name </label>
                                            <asp:TextBox ID="txtfamilydoc" runat="server" class="form-control" placeholder="Family Doctor"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-3">
                                            <label>Family Doctor Mobile </label>
                                            <asp:TextBox ID="txtdocmobile" runat="server" class="form-control" placeholder="Doctor Mobile"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="basic-form">
                                    <h5 class="fs-title">Health History</h5>
                                    <div class="form-row">
                                        <div class="form-group col-md-6">
                                            <label>Current Health Issues</label>
                                            <asp:TextBox ID="txtreason" runat="server" class="form-control" placeholder="Health Issues"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label>Medical History</label>
                                            <asp:TextBox ID="txtmedicalhistory" runat="server" class="form-control" placeholder="Medical History" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Prescriptions </label>
                                            <asp:FileUpload ID="prescriptfile" runat="server" class="form-control" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Reports </label>
                                            <asp:FileUpload ID="filereports" runat="server" class="form-control" />
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Taking any medications, currently? </label>
                                            <br />
                                            <asp:RadioButton ID="rdoyes" runat="server" Text="Yes" CssClass="mr-3" GroupName="optradio" />
                                            <asp:RadioButton ID="rdono" runat="server" Text="No" GroupName="optradio" />
                                        </div>
                                        <div class="form-group col-md-12" id="medicindiv" runat="server" style="display: none">
                                            <label>Please list them here</label>
                                            <asp:TextBox ID="txtmediciitems" runat="server" class="form-control" placeholder="Medicins" TextMode="MultiLine"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="basic-form">
                                    <h5 class="fs-title">Insurance Details</h5>
                                    <div class="form-row">
                                        <div class="form-group col-md-4">
                                            <label>Insurance Company</label>
                                            <asp:TextBox ID="txtinsurancecompany" runat="server" class="form-control" placeholder="Insurance Company"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Insurance Id </label>
                                            <asp:TextBox ID="txtinsuranceid" runat="server" class="form-control" placeholder="Insurance Id"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-md-4">
                                            <label>Insurance Type</label>
                                            <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlinsutype">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group col-md-12">
                                            <label>Insurance Details </label>
                                            <asp:TextBox ID="txtinsudetails" runat="server" class="form-control" placeholder="Insurance Details"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick=" btnsubmit_OnClick" />
                                     <asp:Button ID="btnedit" runat="server" class="btn btn-dark" Text="Edit" OnClick=" btnedit_OnClick" Visible="false" />
                                    </center>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script>
            function calculateAge() {
                // Get the entered date of birth
                var dobString = document.getElementById('<%=txtdob.ClientID %>').value;

                    // Calculate age
                    var dob = new Date(dobString);
                    var today = new Date();
                    var age = today.getFullYear() - dob.getFullYear();

                    // Check if the birthday hasn't occurred yet this year
                    if (today.getMonth() < dob.getMonth() || (today.getMonth() === dob.getMonth() && today.getDate() < dob.getDate())) {
                        age--;
                    }

                    // Update the age textbox
                    document.getElementById('<%=txtage.ClientID %>').value = age;
        }
        </script>
        <script>
            // Get references to the radio buttons and the textbox
            var rdoyes = document.getElementById('<%= rdoyes.ClientID %>');
            var rdono = document.getElementById('<%= rdono.ClientID %>');
            var txtmediciitems = document.getElementById('<%= medicindiv.ClientID %>');

            // Function to handle radio button changes
            function handleRadioButtonChange() {
                // If "Yes" is selected, show the textbox; otherwise, hide it
                txtmediciitems.style.display = rdoyes.checked ? 'block' : 'none';
            }

            // Add event listener to the "Yes" radio button
            rdoyes.addEventListener('change', handleRadioButtonChange);

            // Add event listener to the "No" radio button
            rdono.addEventListener('change', function () {
                // If "No" is selected, hide the textbox; otherwise, show it
                txtmediciitems.style.display = rdono.checked ? 'none' : 'block';
            });

            // Trigger the function on page load
            window.onload = function () {
                handleRadioButtonChange(); // Call the function to handle initial visibility
            };
        </script>
        <!-- #/ container -->
    </div>
    <!--**********************************
            Content body end
        ***********************************-->



   
    <!--**********************************
        Main wrapper end
    ***********************************-->

    <!--**********************************
        Scripts
    ***********************************-->
    <script src="../plugins/common/common.min.js"></script>
    <script src="../js/custom.min.js"></script>
    <script src="../js/settings.js"></script>
    <script src="../js/gleek.js"></script>
    <script src="../js/styleSwitcher.js"></script>

    <script src="../plugins/validation/jquery.validate.min.js"></script>
    <script src="../plugins/validation/jquery.validate-init.js"></script>

</body>

</html>
