<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Add_Supplier.aspx.cs" Inherits="Master_Admin_Add_Supplier" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:label id="id" runat="server" visible="false"></asp:label>
    <asp:label id="mastername" runat="server" visible="false"></asp:label>
    <asp:label id="lblid" runat="server" visible="false"></asp:label>
    <asp:label id="lblpass" runat="server" visible="false"></asp:label>
    <asp:label id="lblmasterid" runat="server" visible="false"></asp:label>
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
                        <h4 class="card-title">Add Supplier</h4>

                        <form>
                            <div class="basic-form">
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Supplier Name <span style="color: red">*</span></label>
                                        <asp:textbox id="txtname" runat="server" class="form-control" placeholder="Name" required></asp:textbox>
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
                                        <asp:textbox id="txtmobile" runat="server" class="form-control" placeholder="Mobile" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Alternate Mobile</label>
                                        <asp:textbox id="txtaltmobile" runat="server" class="form-control" placeholder="Alternate Mobile"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Gmail</label>
                                        <asp:textbox id="txtgmail" runat="server" class="form-control" placeholder="Gmail"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>GST No <span style="color: red">*</span></label>
                                        <asp:textbox id="txtgstno" runat="server" class="form-control" placeholder="GST No" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label>Address</label>
                                        <asp:textbox id="txtaddress" runat="server" class="form-control" placeholder="Address"></asp:textbox>
                                    </div>

                                </div>
                            </div>

                            <div class="basic-form">
                                <h5 class="fs-title">Bank Details</h5>
                                <div class="form-row">

                                    <div class="form-group col-md-3">
                                        <label>Bank Name <span style="color: red">*</span></label>
                                        <asp:textbox id="txtbankname" runat="server" class="form-control" placeholder="Bank Name" required></asp:textbox>
                                    </div>


                                    <div class="form-group col-md-3">
                                        <label>IFSC Code <span style="color: red">*</span></label>
                                        <asp:textbox id="txtifsc" runat="server" class="form-control" placeholder="IFSC" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Branch <span style="color: red">*</span></label>
                                        <asp:textbox id="txtbranch" runat="server" class="form-control" placeholder="Branch" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Account Number <span style="color: red">*</span></label>
                                        <asp:textbox id="txtaccno" runat="server" class="form-control" placeholder="Account Number" required></asp:textbox>
                                    </div>

                                </div>
                            </div>

                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_OnClick" />
                                    </center>
                        </form>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

