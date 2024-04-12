<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Add_Products.aspx.cs" Inherits="Master_Admin_Add_Products" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        th, td {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblimg" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblmimg" runat="server" Visible="false"></asp:Label>
     <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Add Products</h3>
                        <form>
                            <div class="basic-form">
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Peoduct Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlprotype">
                                            <asp:ListItem Text="Select Product Type" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Peoduct Sub Type</label>
                                        <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlprosubtype">
                                            <asp:ListItem Text="Select Product Sub Type" Value=""></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Product Name</label>
                                        <asp:TextBox ID="txtproductname" runat="server" class="form-control" placeholder="Product Name"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Product Price</label>
                                        <asp:TextBox ID="txtproprice" runat="server" class="form-control" placeholder="Product Price"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Product Quantity</label>
                                        <asp:TextBox ID="txtquantity" runat="server" class="form-control" placeholder="Quantity"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Image</label>
                                        <asp:FileUpload ID="fileimage" runat="server" class="form-control" />
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Multiple Image</label>
                                        <asp:FileUpload ID="filemimage" runat="server" class="form-control" />
                                    </div>
                                    <div class="form-group col-md-8">
                                        <label>Products Details</label>
                                        <asp:TextBox ID="txtdetails" runat="server" class="form-control" placeholder="Products Details"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit" OnClick="btnsubmit_Click"  />
                                    </center>
                        </form>
                        <div class="table-responsive">
                            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Product_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvProduct_RowDeleting" OnRowCommand="gvProduct_RowCommand"
                                OnRowUpdating="gvProduct_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("Product_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Product_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Sub-Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsubtype" runat="server" Text='<%# Eval("Product_Sub_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblproductname" runat="server" Text='<%# Eval("Product_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprice" runat="server" Text='<%# Eval("Price")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lblquantity" runat="server" Text='<%# Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Image">
                                        <ItemTemplate>
                                            <asp:Label ID="lblimage" runat="server" Text='<%# Eval("Image")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("Product_Details")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Product_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Product_Id")%>'>
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

