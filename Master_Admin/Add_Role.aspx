<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Add_Role.aspx.cs" Inherits="Master_Admin_Add_Role" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <style>
        td, th {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Add Role</h3>
                        <form>
                            <div class="basic-form">
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>Role <span style="color: red">*</span></label>
                                        <asp:textbox id="txtrole" runat="server" class="form-control" placeholder="Role" required></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:button id="btnsubmit" runat="server" class="btn btn-dark" text="Submit" style="margin-left: 25px; margin-top: 32px;" onclick="btnsubmit_OnClick" />
                                    </div>

                                </div>
                            </div>
                        </form>

                        <div class="table-responsive">
                            <asp:gridview id="gvProductType" runat="server" autogeneratecolumns="False" cssclass="table table-striped table-bordered zero-configuration"
                                showheaderwhenempty="True" emptydatatext="Sorry !! No Admin Found" emptydatarowstyle-forecolor="Red"
                                emptydatarowstyle-horizontalalign="Center" emptydatarowstyle-backcolor="White"
                                datakeynames="Role_Id" allowpaging="false" pagesize="20" backcolor="White" bordercolor="#DEDFDE"
                                borderstyle="None" borderwidth="1px" cellpadding="4" forecolor="Black" gridlines="Vertical"
                                horizontalalign="Center" onrowdeleting="gvProductType_RowDeleting" onrowcommand="gvProductType_RowCommand"
                                onrowupdating="gvProductType_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("Role_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Role_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Unit_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>--%>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Role_Id")%>'>
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
                            </asp:gridview>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

