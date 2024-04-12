<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.master" AutoEventWireup="true" CodeFile="Shift_Schedule.aspx.cs" Inherits="Staff_Shift_Schedule" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        /* CSS style to add margin between checkbox and text */
        .form-check input[type="checkbox"] {
            margin-right: 15px; /* Adjust the value to your preference */
        }
        td,th{
            font-size:small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="name" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
      <asp:Label ID="lblshifttime" runat="server" Visible="false"></asp:Label>
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
                                        <label>Staff <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlstaff" OnSelectedIndexChanged="ddlstaffchanged" AutoPostBack="True" required>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Role <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlrole" required>
                                            <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Shift Date</label>
                                        <asp:TextBox ID="txtdate" runat="server" class="form-control" TextMode="date"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Shift Form Time</label>
                                        <div class="input-group clockpicker" data-placement="bottom" data-align="top" data-autoclose="false">
                                            <asp:TextBox ID="txtfromtime" runat="server" class="form-control ft" placeholder="Form Time"></asp:TextBox>
                                            <span class="input-group-append"><span class="input-group-text"><i class="fa fa-clock-o"></i></span></span>
                                        </div>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Shift To Time</label>
                                        <div class="input-group clockpicker" data-placement="bottom" data-align="top" data-autoclose="false">
                                            <asp:TextBox ID="txttotime" runat="server" class="form-control tt" placeholder="To Time"></asp:TextBox>
                                            <span class="input-group-append"><span class="input-group-text"><i class="fa fa-clock-o"></i></span></span>
                                        </div>
                                    </div>

                                    <div class="form-group col-md-4">
                                        <label>Shift Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlshifttype">
                                            <asp:ListItem Text="Select Shift" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Night" Value="Night"></asp:ListItem>
                                            <asp:ListItem Text="Day" Value="Day"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Assign To Department <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddldepartment">
                                        </asp:DropDownList>
                                    </div>
                                    <%-- <div class="form-group col-md-4">
                                        <label>Assign To Unit <span style="color: red">*</span></label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlunit">
                                           
                                        </asp:DropDownList>
                                    </div>--%>
                                </div>
                            </div>

                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_OnClick"/>
                                    </center>

                        </form>
                        <div class="table-responsive">
                            <asp:GridView ID="gvShift" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Shift_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvShift_RowDeleting" OnRowCommand="gvShift_RowCommand"
                                OnRowUpdating="gvShift_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Shift Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("Shift_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Staff Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblname" runat="server" Text='<%# Eval("Staff_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Role">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrole" runat="server" Text='<%# Eval("Role")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shift Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("Shift_Date")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shift Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltime" runat="server" Text='<%# Eval("Shift_Time")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shift Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Shift_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldepartment" runat="server" Text='<%# Eval("Departmet")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Shift_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Shift_Id")%>'>
                                             <img src="../icons/delete.png" alt="Delete" width="25" height="25" />
                                            </asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <HeaderStyle BackColor="#967ADC" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                <EmptyDataRowStyle HorizontalAlign="Center" BackColor="White" ForeColor="Red"></EmptyDataRowStyle>
                                <FooterStyle BackColor="#CCCC99" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
