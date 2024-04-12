<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="View_Bills.aspx.cs" Inherits="Master_Admin_View_Bills" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td, th {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="mastername" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpaidamt" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblbalamt" runat="server" Visible="false"></asp:Label>

     <asp:Label ID="lblpaidamount" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbltotalamount" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">View Bills</h3>
                        <div class="table-responsive" style="overflow: auto">
                            <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Bill_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvBills_RowDeleting" OnRowCommand="gvBills_RowCommand"
                                OnRowUpdating="gvBills_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="BIll Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSuuplierId" runat="server" Text='<%# Eval("Bill_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bill No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbilno" runat="server" Text='<%# Eval("Bill_No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBilldate" runat="server" Text='<%# Eval("Bill_Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcat" runat="server" Text='<%# Eval("Category")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Suplier Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblsupplier" runat="server" Text='<%# Eval("Suplier")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" Text='<%# Eval("Status")%>' Visible="false"></asp:Label>
                                            <span class="badge <%# GetBadgeClass(Eval("Status")) %>">
                                                <%# Eval("Status") %>
                                            </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Pament_Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Paid">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpaid" runat="server" Text='<%# Eval("Paid_Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbalance" runat="server" Text='<%# Eval("Balance_Amount")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <div class="dropdown custom-dropdown">
                                                <div data-toggle="dropdown"><i class="fa fa-ellipsis-v"></i></div>
                                                <div class="dropdown-menu dropdown-menu-left" style="width: 140px">
                                                    <asp:LinkButton ID="lnkview" runat="server" Style="font-size: 16px;" Text="&nbsp;Pay" class="fa fa-eye dropdown-item" CommandName="Pay" CommandArgument='<%# Eval("Bill_Id")%>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" Style="font-size: 16px;" Text="&nbsp;Delete" class="fa fa-trash dropdown-item" CommandName="Delete1" CommandArgument='<%# Eval("Bill_Id")%>'></asp:LinkButton>
                                                </div>
                                            </div>
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

    <div class="modal fade" id="modalview">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">View Expense Details</h5>
                    <button type="button" class="close" data-dismiss="modal">
                        <span>&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">

                        <div class="row">
                            <!-- Widget Item -->
                            <div class="col-md-12">
                                <div class="widget-area-2 proclinic-box-shadow">
                                    <h3 class="widget-title">Expense Details</h3>
                                    <div class="row no-mp">
                                        <div class="col-md-6">

                                            <div class="table-responsive">
                                                <table class="table header-border table-hover verticle-middle">
                                                    <tbody>
                                                        <tr>
                                                            <td><strong>Bill No</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblbillno" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Title</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lbltile" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Suplier Name</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblname" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Status</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <div class="col-md-6">
                                            <div class="table-responsive">
                                                <table class="table header-border table-hover verticle-middle">
                                                    <tbody>
                                                        <tr>
                                                            <td><strong>Bill Date</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblBilldate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Category</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblcat" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Attachment</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblattach" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Description</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lbldesc" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="col-md-12" runat="server" id="paydiv">
                                            <h3 class="widget-title">Pay Expense</h3>
                                            <div class="row">
                                                <div class="form-group col-md-4">
                                                    <label>Amount <span style="color: red">*</span></label>
                                                    <asp:TextBox ID="txtamount" runat="server" class="form-control" placeholder="Balance Amount"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <label>Pay Amount <span style="color: red">*</span></label>
                                                    <asp:TextBox ID="txtpay" runat="server" class="form-control" placeholder="Pay" onkeyup="calculateBalance()"></asp:TextBox>
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <label>Balance Amount <span style="color: red">*</span></label>
                                                    <asp:TextBox ID="txtbalance" runat="server" class="form-control" placeholder="Paid Amount" Text="0.00"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- /Widget Item -->

                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnPay" runat="server" CssClass="btn btn-primary" Text="Pay" OnClick="btnPay_Onclick" />
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
        function calculateBalance() {
            // Get the values from the textboxes
            var payAmt = parseFloat(document.getElementById('<%= txtamount.ClientID %>').value);
            var paidAmt = parseFloat(document.getElementById('<%= txtpay.ClientID %>').value);

            // Calculate the balance
            var balanceAmt = payAmt - paidAmt;

            // Update the balance amount textbox
            document.getElementById('<%= txtbalance.ClientID %>').value = balanceAmt.toFixed(2);
        }
    </script>

</asp:Content>


