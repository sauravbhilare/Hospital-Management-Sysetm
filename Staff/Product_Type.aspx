<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffMaster.master" AutoEventWireup="true" CodeFile="Product_Type.aspx.cs" Inherits="Staff_Product_Type" %>

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
                        <h3 class="card-title">Add Product Type</h3>
                        <form>
                            <div class="basic-form">
                                <div class="form-row">
                                    <div class="form-group col-md-6">
                                        <label>Product Type <span style="color: red">*</span></label>
                                        <asp:TextBox ID="txtpro" runat="server" class="form-control" placeholder="Product Type" required></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" Style="margin-left: 25px; margin-top: 32px;" OnClick="btnsubmit_OnClick" />
                                    </div>

                                </div>
                            </div>
                        </form>
                        <div class="table-responsive">
                            <asp:GridView ID="gvProductType" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Type_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvProductType_RowDeleting" OnRowCommand="gvProductType_RowCommand"
                                OnRowUpdating="gvProductType_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("Type_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Product_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <%--<asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Type_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>--%>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Type_Id")%>'>
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



