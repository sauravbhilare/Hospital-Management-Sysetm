<%@ Page Title="" Language="C#" MasterPageFile="~/Patient/PatientMaster.master" AutoEventWireup="true" CodeFile="Checkup.aspx.cs" Inherits="Patient_Checkup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td, th {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="src1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblpatient" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblpname" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblappid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lbldocid" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">View Checked Patients</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="gvCheckup" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Check_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvCheckup_RowDeleting" OnRowCommand="gvCheckup_RowCommand"
                                OnRowUpdating="gvCheckup_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Master Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCheckid" runat="server" Text='<%# Eval("Check_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paitent Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPatient" runat="server" Text='<%# Eval("Patient_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CheckUp Details">
                                        <ItemTemplate>
                                            <asp:Label ID="lblapptype" runat="server" Text='<%# Eval("Check_Up_Details")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Prescribe Test">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltest" runat="server" Text='<%# Eval("Prescribe_Test")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Visited Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblvisitdate" runat="server" Text='<%# Eval("Checked_On", "{0:dd/MM/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <div class="dropdown custom-dropdown">
                                                <div data-toggle="dropdown"><i class="fa fa-ellipsis-v"></i></div>
                                                <div class="dropdown-menu dropdown-menu-left" style="width: 140px">
                                                    <asp:LinkButton ID="lnkview" runat="server" Style="font-size: 16px;" Text="&nbsp;View Summary" class="fa fa-eye dropdown-item" CommandName="View" CommandArgument='<%# Eval("Check_Id")%>'></asp:LinkButton>
                                                    <%--   <asp:LinkButton ID="lnkUpdate" runat="server" Style="font-size: 16px;" Text="&nbsp;Edit" class="fa fa-edit dropdown-item" CommandName="Update" CommandArgument='<%# Eval("Check_Id")%>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkcancle" runat="server" Style="font-size: 16px;" Text="&nbsp;Cancle" class="fa fa-xing dropdown-item" CommandName="cancle" CommandArgument='<%# Eval("Check_Id")%>'></asp:LinkButton>--%>
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
    <div class="modal fade bd-example-modal-lg" id="ViewModal" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="Closebtn1" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="modal-header">
                            <h5 class="modal-title">Medicine History</h5>
                            <%-- <button type="button" class="close" data-dismiss="modal">
                                <span>&times;</span>
                            </button>--%>
                        </div>
                        <div class="modal-body">
                            <%--  <div class="row mb-2">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Name : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblname" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Mobile. : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblmobile" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Gmail : </b>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Label ID="lblgmail" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="row mb-2">
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <b>Reason : </b>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lblreason" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Type : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lbltype1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Date : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblappdate" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-5">
                                            <b>Time Slot : </b>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lbltimeslot" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Doctor : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lbldoct" runat="server" Text=""></asp:Label><asp:Label ID="Mobile2" runat="server" Text=""></asp:Label><asp:Label ID="Mobile3" runat="server" Text=""></asp:Label><asp:Label ID="Mobile4" runat="server" Text=""></asp:Label><asp:Label ID="Mobile5" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <b>Status : </b>
                                        </div>
                                        <div class="col-md-8">
                                            <asp:Label ID="lblstatus" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row mb-2">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-2">
                                            <b>Check Details : </b>
                                        </div>
                                        <div class="col-md-10">
                                            <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="True" EmptyDataText="No records Found" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red" CssClass="table table-striped trying">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSrNo" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Sub_Type") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medicine Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmedicinename" runat="server" Text='<%# Eval("Medicine_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medication Time">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Medication_Time") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medication Taking">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmtaking" runat="server" Text='<%# Eval("Medication_Taking") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dosage">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDosage" runat="server" Text='<%# Eval("Medication_Dosage") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="Closebtn1" runat="server" OnClick="Closebtn1_Click" type="button" Text="Close" class="btn btn-secondary" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script>

        function showModel3() {
            $('#ViewModal').modal('show')
        }
    </script>
</asp:Content>

