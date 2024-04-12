<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.master" AutoEventWireup="true" CodeFile="Patient_Registration.aspx.cs" Inherits="Staff_Patient_Registration" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblstaffid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpatientid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblprecript" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblreport" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Patients Registration</h3>
                        <form>
                            <div class="basic-form">
                                <h5 class="fs-title">Personal Details</h5>

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
                                        <asp:TextBox ID="txtdob" runat="server" class="form-control" placeholder="" TextMode="date" onchange="calculateAge()"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Age</label>
                                        <asp:TextBox ID="txtage" runat="server" class="form-control" placeholder="Age"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Mobile <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Mobile" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Alternate Mobile</label>
                                        <asp:TextBox ID="txtaltmobile" runat="server" class="form-control" placeholder="Alternate Mobile"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Gmail</label>
                                        <asp:TextBox ID="txtgmail" runat="server" class="form-control" placeholder="Gmail"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="basic-form">
                                <h5 class="fs-title">Emergency Contact</h5>
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Fisrt Name</label>
                                        <asp:TextBox ID="txtefname" runat="server" class="form-control" placeholder="Fisrt Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Last Name</label>
                                        <asp:TextBox ID="txtelname" runat="server" class="form-control" placeholder="Last Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Relationship</label>
                                        <asp:TextBox ID="txtrelationship" runat="server" class="form-control" placeholder="Relationship"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Mobile </label>
                                        <asp:TextBox ID="txtemobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Family Doctor Name </label>
                                        <asp:TextBox ID="txtfamilydoc" runat="server" class="form-control" placeholder="Family Doctor"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Family Doctor Mobile </label>
                                        <asp:TextBox ID="txtdocmobile" runat="server" class="form-control" placeholder="Doctor Mobile"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="basic-form">
                                <h5 class="fs-title">Health History</h5>
                                <div class="form-row">
                                    <div class="form-group col-md-12">
                                        <label>Current Health Issues</label>
                                        <asp:TextBox ID="txtreason" runat="server" class="form-control" placeholder="Health Issues"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-12">
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
                                        <asp:TextBox ID="txtinsuranceid" runat="server" class="form-control" placeholder="Insurance Id" ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Insurance Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlinsutype">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label>Insurance Details </label>
                                        <asp:TextBox ID="txtinsudetails" runat="server" class="form-control" placeholder="Insurance Details" TextMode="password"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_OnClick"/>
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


</asp:Content>

