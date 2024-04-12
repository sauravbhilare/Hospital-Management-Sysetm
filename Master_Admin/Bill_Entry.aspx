<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="Bill_Entry.aspx.cs" Inherits="Master_Admin_Bill_Entry" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:label id="id" runat="server" visible="false"></asp:label>
    <asp:label id="mastername" runat="server" visible="false"></asp:label>
    <asp:label id="lblid" runat="server" visible="false"></asp:label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">

                        <form>

                            <div class="basic-form">
                                <h5 class="fs-title">Bill Entry</h5>
                                <div class="form-row">
                                    <div class="form-group col-md-4">
                                        <label>Bill/Reference No</label>
                                        <asp:textbox id="txtbillno" runat="server" class="form-control" placeholder="Enter Bill/Reference No"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Bill Date <span style="color: red">*</span></label>
                                        <asp:textbox id="txtbilldate" runat="server" class="form-control" textmode="date" placeholder="DD/MM/YYYY"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Title <span style="color: red">*</span></label>
                                        <asp:textbox id="txttitle" runat="server" class="form-control" placeholder="Title"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Category <span style="color: red">*</span></label>
                                        <asp:dropdownlist runat="server" cssclass="form-control mr-sm-2" id="ddlcategory">
                                        </asp:dropdownlist>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Suplier <span style="color: red">*</span></label>
                                        <asp:dropdownlist runat="server" cssclass="form-control mr-sm-2" id="ddlsupplier">
                                        </asp:dropdownlist>
                                    </div>
                                    <div class="form-group col-md-4">
                                        <label>Attachment</label>
                                        <asp:fileupload id="fileAttach" runat="server"></asp:fileupload>
                                    </div>
                                    <div class="form-group col-md-12">
                                        <label>Description</label>
                                        <asp:textbox id="txtdescription" runat="server" class="form-control" placeholder="Description"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                            <hr />
                            <div class="basic-form">
                                <h5 class="fs-title">Paymet Details</h5>
                                <div class="form-row">
                                    <div class="form-group col-md-3">
                                        <label>Status <span style="color: red">*</span></label>
                                        <asp:dropdownlist runat="server" cssclass="form-control mr-sm-2" id="ddlpaystatus" onchange="handlePaymentStatusChange()">
                                            <asp:ListItem Text="Payment Status" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text="Unpaid" Value="Unpaid"></asp:ListItem>
                                            <asp:ListItem Text="Partial Paid" Value="Partial Paid"></asp:ListItem>
                                            <asp:ListItem Text="Paid" Value="Paid"></asp:ListItem>
                                        </asp:dropdownlist>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Payment Amount <span style="color: red">*</span></label>
                                        <asp:textbox id="txtpayamt" runat="server" class="form-control" placeholder="Payment Amount" onkeyup="calculateBalance()"></asp:textbox>
                                    </div>
                                    <div id="paidAmountDiv" class="form-group col-md-3">
                                        <label>Paid Amount <span style="color: red">*</span></label>
                                        <asp:textbox id="txtpaidamt" runat="server" class="form-control" placeholder="Paid Amount" onkeyup="calculateBalance()"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-3">
                                        <label>Balance Amount <span style="color: red">*</span></label>
                                        <asp:textbox id="txtbalanceamt" runat="server" class="form-control" placeholder="Balance Amount"></asp:textbox>
                                    </div>

                                    <%--  <div class="form-group col-md-4" id="txtbalamt" runat="server" style="display: none">
                                        <label>Payment Mode</label>
                                        <asp:dropdownlist runat="server" cssclass="form-control mr-sm-2" id="ddlpaymentmode" onchange="handlePaymentModeChange()">
                                                    <asp:ListItem Text="Payment Mode" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Cash" Value="Cash"></asp:ListItem>
                                                    <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
                                                    <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                                </asp:dropdownlist>
                                    </div>
                                    <div class="form-group col-md-4" id="trid" runat="server" style="display: none">
                                        <label>Transaction Id</label>
                                        <asp:textbox id="txttransactionid" runat="server" class="form-control" placeholder="Transaction Id"></asp:textbox>
                                    </div>

                                    <div class="form-group col-md-4" id="cqno" runat="server" style="display: none">
                                        <label>Cheque No</label>
                                        <asp:textbox id="txtchqno" runat="server" class="form-control" placeholder="Cheque No"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4" id="cqdate" runat="server" style="display: none">
                                        <label>Cheque Date</label>
                                        <asp:textbox id="txtchqdate" runat="server" class="form-control" placeholder="Cheque Date"></asp:textbox>
                                    </div>
                                    <div class="form-group col-md-4" id="cqstatus" runat="server" style="display: none">
                                        <label>Cheque Status</label>
                                        <asp:textbox id="chqstatus" runat="server" class="form-control" placeholder="Cheque Status"></asp:textbox>
                                    </div>--%>
                                </div>
                            </div>
                            <center>
                                <asp:Button ID="btnsubmit" runat="server" class="btn btn-dark" Text="Create Bill" OnClick="btnsubmit_Onclick"/>
                                    </center>

                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function calculateBalance() {
            // Get the values from the textboxes
            var payAmtInput = document.getElementById('<%= txtpayamt.ClientID %>').value;
        var paidAmtInput = document.getElementById('<%= txtpaidamt.ClientID %>').value;

        // Parse the input values as floats
        var payAmt = parseFloat(payAmtInput);
        var paidAmt = parseFloat(paidAmtInput);

        // Check if the input values are valid numbers
        if (!isNaN(payAmt) && !isNaN(paidAmt)) {
            // Calculate the balance
            var balanceAmt = payAmt - paidAmt;

            // Update the balance amount textbox
            document.getElementById('<%= txtbalanceamt.ClientID %>').value = balanceAmt.toFixed(2);
        } else {
            // If either input is not a valid number, set balance amount to 0
            document.getElementById('<%= txtbalanceamt.ClientID %>').value = payAmtInput;
        }
    }
    </script>


    <script type="text/javascript">
        function handlePaymentStatusChange() {
            var ddlStatus = document.getElementById('<%= ddlpaystatus.ClientID %>');
            var divPaidAmount = document.getElementById('paidAmountDiv');

            // Get the selected value of the dropdown list
            var selectedValue = ddlStatus.options[ddlStatus.selectedIndex].value;

            // Show/hide the div containing the Paid Amount textbox based on the selected value
            if (selectedValue === "Unpaid") {
                divPaidAmount.style.display = "none";
            } else {
                divPaidAmount.style.display = "block";
            }
        }
    </script>

</asp:Content>
