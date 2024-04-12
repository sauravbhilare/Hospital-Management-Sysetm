<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.master" AutoEventWireup="true" CodeFile="Appointment_Schedule.aspx.cs" Inherits="Staff_Appointment_Schedule" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblstaffid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblappid" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Appointment Schedule</h3>
                        <form>
                            <div class="basic-form">

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Paitent Name</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlpaitentname" OnSelectedIndexChanged="ddlpaitentname_OnSelectedIndexChanged" AutoPostBack="true">
                                            <asp:ListItem Value="-1">--Select--</asp:ListItem>

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
                                        <label>Gender</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlgender">
                                            <asp:ListItem Text="Choose Gender" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:DropDownList>
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

                                    <div class="form-group col-md-4">
                                        <label>Appointment Reason</label>
                                        <asp:TextBox ID="txtappreason" runat="server" class="form-control" placeholder="Appointment Reason"></asp:TextBox>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <label>Appointment Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlaptype">
                                            <asp:ListItem Text="Appointment Type" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Medical Examination" Value="Medical Examination"></asp:ListItem>
                                            <asp:ListItem Text="Doctor Check" Value="Doctor Check"></asp:ListItem>
                                            <asp:ListItem Text="Result Analysis" Value="Result Analysis"></asp:ListItem>
                                            <asp:ListItem Text="Check-Up" Value="Check-Up"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label>Address</label>
                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Date</label>
                                        <asp:TextBox ID="txtappointdate" runat="server" class="form-control" placeholder="" TextMode="date" onchange="calculateAge()"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Time Slot</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddltimeslot">
                                            <asp:ListItem Text="Time Slot" Value=""></asp:ListItem>
                                            <asp:ListItem Text="10.00 To 11.00" Value="10.00 To 11.00"></asp:ListItem>
                                            <asp:ListItem Text="11.00 To 12.00" Value="11.00 To 12.00"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Contact Preference</label>
                                        <br />
                                        <asp:RadioButton ID="rdbgmail" runat="server" Text="Gmail" CssClass="mr-3" GroupName="optradio" />
                                        <asp:RadioButton ID="rdbmobile" runat="server" Text="Mobile" GroupName="optradio" />
                                    </div>

                                       <div class="form-group col-md-4">
                                        <label>Appoint To</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlappoint">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </div>

                                </div>
                            </div>


                            <center>
                                <asp:Button ID="btnshedule" runat="server" class="btn btn-dark" Text="Schedule" OnClick="btnshedule_OnClick"  />
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


</asp:Content>

