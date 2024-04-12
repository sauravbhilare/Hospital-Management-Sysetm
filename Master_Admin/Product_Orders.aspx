<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Product_Orders.aspx.cs" Inherits="Master_Admin_Product_Oorder" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="id" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="mastername" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">Product Orders</h3>
                        <form>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="basic-form">
                                        <h5 class="fs-title">Supplier Details</h5>
                                        <div class="form-row">
                                            <div class="form-group col-md-4">
                                                <label>Supplier Name</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlprotype">
                                                    <asp:ListItem Text="Select Name" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Mobile</label>
                                                <asp:TextBox ID="txtmobile" runat="server" class="form-control" placeholder="Mobile"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Order Date</label>
                                                <asp:TextBox ID="txtdate" runat="server" class="form-control" TextMode="date" placeholder="DD/MM/YYYY"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-12">
                                                <label>Address</label>
                                                <asp:TextBox ID="txtadress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="basic-form">
                                        <h5 class="fs-title">Add Products</h5>
                                        <div class="form-row">
                                            <div class="form-group col-md-4">
                                                <label>Product Type</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlproducttype" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged">
                                                    <asp:ListItem Text="Select Product Type" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Product Sub Type</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlproductsubtype" AutoPostBack="true" OnSelectedIndexChanged="OnSelectedIndexChanged_SubType">
                                                    <asp:ListItem Text="Select Product Sub Type" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Product Name</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlproductname">
                                                    <asp:ListItem Text="Select Product Name" Value=""></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Quantity</label>
                                                <asp:TextBox ID="txtquantity" runat="server" class="form-control" placeholder="Quantity" onchange="calculateTotal()"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Product Price</label>
                                                <asp:TextBox ID="txtproprice" runat="server" class="form-control" placeholder="Product Price" onchange="calculateTotal()"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Total Amount</label>
                                                <asp:TextBox ID="txttotal" runat="server" class="form-control" placeholder="Total"></asp:TextBox>
                                            </div>
                                        </div>
                                        <center>
                                <asp:Button ID="btnadd" runat="server" class="btn btn-dark" Text="Add" OnClick="btnadd_Onclick"  />
                                    </center>
                                        <br />
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridMedicine" runat="server" AutoGenerateColumns="false" class="table table-bordered">
                                                <Columns>
                                                    <asp:BoundField DataField="SrNo" HeaderText="Sr. No." />
                                                    <asp:BoundField DataField="ProductType" HeaderText="Product Type" />
                                                    <asp:BoundField DataField="ProductSubType" HeaderText="Product Sub Type" />
                                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                                    <asp:BoundField DataField="Quantity" HeaderText="Medication Time" />
                                                    <asp:BoundField DataField="Price" HeaderText="Quantity" />
                                                    <asp:BoundField DataField="Total" HeaderText="Total" />

                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" OnClick="DeleteRow_Click" CommandArgument='<%# Container.DataItemIndex %>' CausesValidation="false">    <i class="fa fa-trash"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <hr />
                                    <div class="basic-form">
                                        <h5 class="fs-title">Paymet Details</h5>
                                        <div class="form-row">
                                            <div class="form-group col-md-4">
                                                <label>Payment Status</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlpaystatus" onchange="handlePaymentStatusChange()">
                                                    <asp:ListItem Text="Payment Status" Value="-1"></asp:ListItem>
                                                    <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                                                    <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Paid</label>
                                                <asp:TextBox ID="txtpaid" runat="server" class="form-control" placeholder="Paid"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <label>Balance</label>
                                                <asp:TextBox ID="txtbalance" runat="server" class="form-control" placeholder="Balance"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4" id="ddlpaymode" runat="server" style="display: none">
                                                <label>Payment Mode</label>
                                                <asp:DropDownList runat="server" CssClass="form-control mr-sm-2" ID="ddlpaymentmode" onchange="handlePaymentModeChange()">
                                                    <asp:ListItem Text="Payment Mode" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group col-md-4" id="trid" runat="server" style="display: none">
                                                <label>Transaction Id</label>
                                                <asp:TextBox ID="txttransactionid" runat="server" class="form-control" placeholder="Transaction Id"></asp:TextBox>
                                            </div>

                                            <div class="form-group col-md-4" id="cqno" runat="server" style="display: none">
                                                <label>Cheque No</label>
                                                <asp:TextBox ID="txtchqno" runat="server" class="form-control" placeholder="Cheque No"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4" id="cqdate" runat="server" style="display: none">
                                                <label>Cheque Date</label>
                                                <asp:TextBox ID="txtchqdate" runat="server" class="form-control" placeholder="Cheque Date"></asp:TextBox>
                                            </div>
                                            <div class="form-group col-md-4" id="cqstatus" runat="server" style="display: none">
                                                <label>Cheque Status</label>
                                                <asp:TextBox ID="chqstatus" runat="server" class="form-control" placeholder="Cheque Status"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Submit"   />
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
    <script>
        function calculateTotal() {
            var quantity = document.getElementById('<%= txtquantity.ClientID %>').value;
            var price = document.getElementById('<%= txtproprice.ClientID %>').value;
            var total = quantity * price;
            document.getElementById('<%= txttotal.ClientID %>').value = total.toFixed(2); // Adjust decimal points as needed
        }
    </script>
    <script>
        function handlePaymentStatusChange() {
            var ddlpaystatus = document.getElementById('<%= ddlpaystatus.ClientID %>');
            var ddlpaymode = document.getElementById('<%= ddlpaymode.ClientID %>');

            var selectedValue = ddlpaystatus.value;

            if (selectedValue === 'Paid') {
                ddlpaymode.style.display = 'block';
            } else {
                ddlpaymode.style.display = 'none';
            }
        }

        function handlePaymentModeChange() {
            var ddlpaymentmode = document.getElementById('<%= ddlpaymentmode.ClientID %>');
            var trid = document.getElementById('<%= trid.ClientID %>');
            var cqno = document.getElementById('<%= cqno.ClientID %>');
            var cqdate = document.getElementById('<%= cqdate.ClientID %>');
            var cqstatus = document.getElementById('<%= cqstatus.ClientID %>');

            var selectedValue = ddlpaymentmode.value;

            trid.style.display = 'none';
            cqno.style.display = 'none';
            cqdate.style.display = 'none';
            cqstatus.style.display = 'none';

            if (selectedValue === 'Online') {
                trid.style.display = 'block';
            } else if (selectedValue === 'Cheque') {
                cqno.style.display = 'block';
                cqdate.style.display = 'block';
                cqstatus.style.display = 'block';
            }
        }
    </script>


</asp:Content>

