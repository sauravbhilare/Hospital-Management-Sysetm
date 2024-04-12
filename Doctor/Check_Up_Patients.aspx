<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/DoctorMaster.master" AutoEventWireup="true" CodeFile="Check_Up_Patients.aspx.cs" Inherits="Doctor_Check_Up_Patients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td, th {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

                                    <%--  <asp:TemplateField HeaderText="Visited Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappcotact" runat="server" Text='<%# Eval("Contact_Preferance")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappstatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--  <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Appointment_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>
                                              <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Appointment_Id")%>'>
                                             <img src="../icons/delete.png" alt="Delete" width="25" height="25" />
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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

