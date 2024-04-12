<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/DoctorMaster.master" AutoEventWireup="true" CodeFile="Check_Up.aspx.cs" Inherits="Doctor_Check_Up" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Add this line to your HTML -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet">
    <style>
        /* CSS style to add margin between checkbox and text */
        .form-check input[type="checkbox"] {
            margin-right: 15px; /* Adjust the value to your preference */
        }

        .widget-49 .widget-49-title-wrapper {
            display: flex;
            align-items: center;
        }

            .widget-49 .widget-49-title-wrapper .widget-49-date-primary {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #edf1fc;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-primary .widget-49-date-day {
                    color: #4e73e5;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-primary .widget-49-date-month {
                    color: #4e73e5;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-secondary {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #fcfcfd;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-secondary .widget-49-date-day {
                    color: #dde1e9;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-secondary .widget-49-date-month {
                    color: #dde1e9;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-success {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #e8faf8;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-success .widget-49-date-day {
                    color: #17d1bd;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-success .widget-49-date-month {
                    color: #17d1bd;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-info {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #ebf7ff;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-info .widget-49-date-day {
                    color: #36afff;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-info .widget-49-date-month {
                    color: #36afff;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-warning {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: floralwhite;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-warning .widget-49-date-day {
                    color: #FFC868;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-warning .widget-49-date-month {
                    color: #FFC868;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-danger {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #feeeef;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-danger .widget-49-date-day {
                    color: #F95062;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-danger .widget-49-date-month {
                    color: #F95062;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-light {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #fefeff;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-light .widget-49-date-day {
                    color: #f7f9fa;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-light .widget-49-date-month {
                    color: #f7f9fa;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-dark {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #ebedee;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-dark .widget-49-date-day {
                    color: #394856;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-dark .widget-49-date-month {
                    color: #394856;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-date-base {
                display: flex;
                align-items: center;
                justify-content: center;
                flex-direction: column;
                background-color: #f0fafb;
                width: 4rem;
                height: 4rem;
                border-radius: 50%;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-date-base .widget-49-date-day {
                    color: #68CBD7;
                    font-weight: 500;
                    font-size: 1.5rem;
                    line-height: 1;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-date-base .widget-49-date-month {
                    color: #68CBD7;
                    line-height: 1;
                    font-size: 1rem;
                    text-transform: uppercase;
                }

            .widget-49 .widget-49-title-wrapper .widget-49-meeting-info {
                display: flex;
                flex-direction: column;
                margin-left: 1rem;
            }

                .widget-49 .widget-49-title-wrapper .widget-49-meeting-info .widget-49-pro-title {
                    color: #3c4142;
                    font-size: 14px;
                }

                .widget-49 .widget-49-title-wrapper .widget-49-meeting-info .widget-49-meeting-time {
                    color: #B1BAC5;
                    font-size: 13px;
                }

        .widget-49 .widget-49-meeting-points {
            font-weight: 400;
            font-size: 13px;
            margin-top: .5rem;
        }

            .widget-49 .widget-49-meeting-points .widget-49-meeting-item {
                display: list-item;
                color: #727686;
            }

                .widget-49 .widget-49-meeting-points .widget-49-meeting-item span {
                    margin-left: .5rem;
                }

        .widget-49 .widget-49-meeting-action {
            text-align: right;
        }

            .widget-49 .widget-49-meeting-action a {
                text-transform: uppercase;
            }

        .icon-blue .fas {
            color: #7571f9;
            font-size: 15px;
        }

        .checkbox-list label {
            display: inline-flex;
            align-items: center;
            margin-right: 15px; /* Adjust this value to set the space between checkbox and text */
        }

        .checkbox-list input[type="checkbox"] {
            margin-right: 5px; /* Adjust this value to set the space between checkbox and text */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="doctorid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="doctorname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblappointmentid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpatientid" runat="server" Visible="false"></asp:Label>
     <asp:Label ID="lblcheckid" runat="server" Visible="false"></asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">

                <div class="card">
                    <div class="card-body">
                        <div style="position: absolute; right: 29px;">
                            <asp:LinkButton ID="btnview" runat="server" CssClass="btn btn-primary" OnClick="btnview_Click">
                             <span class="fa fa-eye"></span>Appointment Details
                            </asp:LinkButton>
                        </div>
                        <h3 class="card-title">Patient Check-Up</h3>
                        <form>
                            <%--      <div class="basic-form">
                                <h5 class="fs-title">Patient Details</h5>

                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Patient Name <span style="color: red">*</span></label>
                                        <asp:textbox id="txtname" runat="server" class="form-control" placeholder="Patient Name" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>DOB</label>
                                        <asp:textbox id="txtdob" runat="server" class="form-control" placeholder="" textmode="date"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Age<span style="color: red">*</span></label>
                                        <asp:textbox id="txtage" runat="server" class="form-control" placeholder="Age" required></asp:textbox>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <label>Gender</label>
                                        <asp:dropdownlist runat="server" cssclass="form-control mr-sm-2" id="ddlgender">
                                            <asp:ListItem Text="Choose Gender" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                            <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                        </asp:dropdownlist>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Mobile <span style="color: red">*</span></label>
                                        <asp:textbox id="txtmobile" runat="server" class="form-control" placeholder="Mobile" required oninput="reflectValue()"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Alternate Mobile</label>
                                        <asp:textbox id="txtaltmobile" runat="server" class="form-control" placeholder="Alternate Mobile"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Gmail</label>
                                        <asp:textbox id="txtgmail" runat="server" class="form-control" placeholder="Gmail"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-8">
                                        <label>Address</label>
                                        <asp:textbox id="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <div class="basic-form">
                                <h5 class="fs-title">Medical Details</h5>
                                <div class="form-row">
                                    <div class="form-group col-md-12">
                                        <label>Reason for appointment <span style="color: red">*</span></label>
                                        <asp:textbox id="txtreason" runat="server" class="form-control" placeholder="Reason for appointment" textmode="multiline"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Prescriptions</label><br />
                                        <asp:linkbutton id="btnpriscript" runat="server" cssclass="btn btn-primary"><i class="fa fa-download">Prescriptions</i></asp:linkbutton>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Reports</label><br />
                                        <asp:linkbutton id="btnreports" runat="server" cssclass="btn btn-primary"><i class="fa fa-download">Reports</i></asp:linkbutton>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label>Medicines <span style="color: red">*</span></label>
                                        <asp:textbox id="txtmedicines" runat="server" class="form-control" placeholder="Medicines" textmode="multiline"></asp:textbox>
                                    </div>
                                </div>
                            </div>--%>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="basic-form">
                                        <h5 class="fs-title">Check-Up Details</h5>
                                        <div class="form-row">
                                            <div class="form-group col-md-12">
                                                <label>Check-Up Details <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txtchkdetails" runat="server" class="form-control" placeholder="Check-Up Details" TextMode="multiline"></asp:TextBox>
                                            </div>
                                            <div class="form-check col-md-12">
                                                <asp:CheckBox ID="chkbox" runat="server" CssClass="" Text="Prescribe Test" AutoPostBack="true" OnCheckedChanged="chkbox_CheckedChanged" />
                                            </div>
                                            <div class="form-group col-md-4" id="droptest" runat="server" visible="false">
                                                <label>Tests</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddltests" onchange="updateTextBox(this)">
                                                    <asp:ListItem Text="Select Tests" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Blood" Value="Blood"></asp:ListItem>
                                                    <asp:ListItem Text="Covid" Value="Covid"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-8" id="testbox" runat="server" visible="false">
                                                <label>Test <span style="color: red">*</span></label>
                                                <asp:TextBox ID="txttest" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>


                                        </div>
                                    </div>
                                    <div class="basic-form">
                                        <h5 class="fs-title">Medication/Dosage Details</h5>
                                        <div class="form-row">

                                            <div class="form-group col-md-4">
                                                <label>Product Type</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlprotype" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged">
                                                    <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Sub-Type</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlmedtype" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged_SubType">
                                                    <asp:ListItem Text="Select Sub-Type" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group col-md-4">
                                                <label>Medicine Name</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlmediname">
                                                    <asp:ListItem Text="Select Product" Value="0"></asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Medication Time</label>
                                                <asp:CheckBoxList ID="cbxMedicationTime" runat="server" CssClass="checkbox-list">
                                                    <asp:ListItem Text="Morning" Value="Morning" />
                                                    <asp:ListItem Text="Afternoon" Value="Afternoon" />
                                                    <asp:ListItem Text="Evening" Value="Evening" />
                                                </asp:CheckBoxList>
                                            </div>
                                            <%--       <div class="form-group col-md-4">
                                                <label>Medication Time</label>
                                                <asp:RadioButtonList ID="rdlmeditime" runat="server">
                                                    <asp:ListItem Text="Morning" Value="Morning" />
                                                    <asp:ListItem Text="Afternoon" Value="Afternoon" />
                                                    <asp:ListItem Text="Evening" Value="Evening" />
                                                </asp:RadioButtonList>
                                            </div>--%>
                                            <div class="form-group col-md-4">
                                                <label>Medication Taking</label>
                                                <asp:RadioButtonList ID="rdlmediintake" runat="server">
                                                    <asp:ListItem Text="Before Meals" Value="Before Meals" />
                                                    <asp:ListItem Text="After Meals" Value="After Meals" />

                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Medication Dosage</label>
                                                <asp:RadioButtonList ID="rdlmedidose" runat="server">
                                                    <asp:ListItem Text="One Tablet" Value="One Tablet" />
                                                    <asp:ListItem Text="Half Tablet" Value="Half Tablet" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <center>
                                <asp:Button ID="btnadd" runat="server" class="btn btn-dark" Text="Add" OnClick="btnadd_OnClick" />
                                    </center>
                                        <br />
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridMedicine" runat="server" AutoGenerateColumns="false" class="table table-bordered">
                                                <Columns>
                                                    <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
                                                    <asp:BoundField DataField="Product_Type" HeaderText="Product Type" />
                                                    <asp:BoundField DataField="Sub_Type" HeaderText="Medicine Type" />
                                                    <asp:BoundField DataField="Medicine_Name" HeaderText="Medicine Name" />
                                                    <asp:BoundField DataField="Medication_Time" HeaderText="Medication Time" />
                                                    <asp:BoundField DataField="Medication_Taking" HeaderText="Medication Taking" />
                                                    <asp:BoundField DataField="Medication_Dosage" HeaderText="Medication Dosage" />

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" OnClick="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>'>
                                                     <i class="fa fa-trash"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                    <div class="basic-form" runat="server" id="pay" visible="false">
                                        <div class="form-row">
                                            <div class="form-group col-md-12">
                                                <label>Doctor Remark</label>
                                                <asp:TextBox ID="txtremark" runat="server" class="form-control" placeholder="Remark" TextMode="multiline"></asp:TextBox>
                                            </div>
                                        </div>
                                        <h5 class="fs-title">Payment Details</h5>
                                        <div class="form-row">
                                            <div class="form-group col-md-4">
                                                <label>Doctor Fees</label>
                                                <asp:TextBox ID="txtdoctorfee" runat="server" CssClass="form-control" placeholder="Doctor Fees"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Doctor Fees</label>
                                                <asp:DropDownList ID="drpmethod" runat="server" CssClass="form-control mr-sm-2" OnSelectedIndexChanged="drpmethodchanged" AutoPostBack="true">
                                                    <asp:ListItem Text="Select Method" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4" runat="server" id="transaction" visible="false">
                                                <label>Transaction Id</label>
                                                <asp:TextBox ID="txttransaction" runat="server" CssClass="form-control" placeholder="Transaction Id"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_OnClick" Visible="false" />
                                    </center>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnsubmit" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="modalview">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">View Doctor Details</h5>
                    <button type="button" class="close" data-dismiss="modal">
                        <span>&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="col-lg-12">
                        <div class="form-row">
                            <div class="col-lg-12">

                                <div class="card-header no-border">
                                </div>
                                <div class="form-row">
                                    <div class="col-md-4">
                                        <div class="card-body pt-0">
                                            <div class="widget-49">
                                                <h5 class="card-title">Appointment Details</h5>
                                                <div class="widget-49-title-wrapper">
                                                    <div class="widget-49-date-primary">
                                                        <asp:Label ID="lbldate" runat="server" CssClass="widget-49-date-day">-</asp:Label>
                                                        <%--   <span class="widget-49-date-day">09</span>--%>
                                                        <asp:Label ID="lblmonth" runat="server" CssClass="widget-49-date-month">-</asp:Label>
                                                        <%-- <span class="widget-49-date-month">apr</span>--%>
                                                    </div>
                                                    <div class="widget-49-meeting-info">
                                                        <%--                                            <span class="widget-49-pro-title">PRO-08235 DeskOpe. Website</span>--%>
                                                        <asp:Label ID="lblname" runat="server" CssClass="widget-49-pro-title" Font-Bold="true">-</asp:Label>
                                                        <asp:Label ID="lbltimeslot" runat="server" CssClass="widget-49-meeting-time" Font-Bold="true">-</asp:Label>
                                                        <%--<span class="widget-49-meeting-time">12:00 to 13.30 Hrs</span>--%>
                                                    </div>
                                                </div>
                                                <ol class="widget-49-meeting-points">
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-calendar-alt"></i>
                                                            <asp:Label ID="lblappointmenttype" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-info-circle"></i>
                                                            <asp:Label ID="lblappointmentreason" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-check-circle"></i>
                                                            <asp:Label ID="lblstatus" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                </ol>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="card-body pt-0">
                                            <div class="widget-49">
                                                <h5 class="card-title">Patients Details</h5>
                                                <%-- <div class="widget-49-title-wrapper">
                                                <div class="widget-49-date-primary">
                                                    <span class="widget-49-date-day">09</span>
                                                    <span class="widget-49-date-month">apr</span>
                                                </div>
                                                <div class="widget-49-meeting-info">
                                                    <asp:label id="Label1" runat="server" cssclass="widget-49-pro-title">Saurav Bhilare</asp:label>
                                                    <span class="widget-49-meeting-time">12:00 to 13.30 Hrs</span>
                                                </div>
                                            </div>--%>
                                                <ol class="widget-49-meeting-points">
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-venus-mars"></i>
                                                            <asp:Label ID="lblgender" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-calendar-alt"></i>
                                                            <asp:Label ID="lbldob" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-user"></i>
                                                            <asp:Label ID="lblage" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-mobile-alt"></i>
                                                            <asp:Label ID="lblmobile" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-map-marker-alt"></i>
                                                            <asp:Label ID="lbladdress" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                </ol>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="card-body pt-0">
                                            <div class="widget-49">
                                                <h5 class="card-title">Health History</h5>
                                                <%--   <div class="widget-49-title-wrapper">
                                                <div class="widget-49-date-primary">
                                                    <span class="widget-49-date-day">09</span>
                                                    <span class="widget-49-date-month">apr</span>
                                                </div>
                                                <div class="widget-49-meeting-info">
                                                    <asp:label id="Label2" runat="server" cssclass="widget-49-pro-title">Saurav Bhilare</asp:label>
                                                    <span class="widget-49-meeting-time">12:00 to 13.30 Hrs</span>
                                                </div>
                                            </div>--%>
                                                <ol class="widget-49-meeting-points">
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-heart fa-1x"></i>
                                                            <asp:Label ID="lblhealthissue" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-notes-medical fa-1x"></i>
                                                            <asp:Label ID="lblmedicalhistory" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue">
                                                            <i class="fas fa-prescription fa-1x"></i>
                                                            <asp:Label ID="lblpriscription" runat="server" Visible="false">-</asp:Label>
                                                            <asp:LinkButton ID="downloadPrescription" runat="server" OnClick="DownloadPrescription_Click" Text="View" Style="margin-left: 10px; color: blue;">
                                                        
                                                            </asp:LinkButton>
                                                        </span>
                                                    </li>
                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue">
                                                            <i class="fas fa-file-medical fa-1x"></i>
                                                            <asp:Label ID="lblreports" runat="server" Visible="false">-</asp:Label>
                                                            <asp:LinkButton ID="downloadReports" runat="server" OnClick="DownloadReports_Click" Text="View" Style="margin-left: 10px; color: blue;">
                                                        
                                                            </asp:LinkButton>

                                                        </span>
                                                    </li>

                                                    <li class="widget-49-meeting-item">
                                                        <span class="icon-blue"><i class="fas fa-pills fa-1x"></i>
                                                            <asp:Label ID="lblmedicins" runat="server">-</asp:Label>
                                                        </span>
                                                    </li>
                                                </ol>


                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <%--  <button type="button" class="btn btn-primary">Save changes</button>--%>
                </div>
            </div>
        </div>
    </div>


    <script>
        function showModel1() {
            $('#modalview').modal('show')
        }
    </script>


    <script>
        function updateTextBox(dropdown) {
            var textBox = document.getElementById('<%= txttest.ClientID %>');
            var selectedValue = dropdown.value;

            // Find the "Select Tests" option
            var selectTestsOption = dropdown.options[0];

            if (selectedValue === "0") {
                // Reset textbox and enable dropdown
                textBox.value = "";
                for (var i = 1; i < dropdown.options.length; i++) {
                    dropdown.options[i].disabled = false;
                }
            } else {
                // Append the selected value to the textbox
                if (textBox.value === "") {
                    textBox.value = selectedValue;
                } else {
                    textBox.value += ", " + selectedValue;
                }

                // Disable the selected option in the dropdown
                for (var i = 1; i < dropdown.options.length; i++) {
                    if (dropdown.options[i].value === selectedValue) {
                        dropdown.options[i].disabled = true;
                        break;
                    }
                }

                // Enable the "Select Tests" option if all options are disabled
                var enableSelectTests = true;
                for (var i = 1; i < dropdown.options.length; i++) {
                    if (!dropdown.options[i].disabled) {
                        enableSelectTests = false;
                        break;
                    }
                }

                if (enableSelectTests) {
                    selectTestsOption.disabled = false;
                }
            }
        }
    </script>

</asp:Content>

