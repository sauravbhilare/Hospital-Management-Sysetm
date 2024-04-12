<%@ Page Title="" Language="C#" MasterPageFile="~/Doctor/DoctorMaster.master" AutoEventWireup="true" CodeFile="View_Appointments.aspx.cs" Inherits="Doctor_View_Appointments" %>

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
                        <h3 class="card-title">View Patients</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="gvAppointment" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="Appointment_Id" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvAppointment_RowDeleting" OnRowCommand="gvAppointment_RowCommand"
                                OnRowUpdating="gvAppointment_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Master Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("Appointment_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--     <asp:TemplateField HeaderText="Gender">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGender" runat="server" Text='<%# Eval("Gender")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%-- <asp:TemplateField HeaderText="DOB">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldob" runat="server" Text='<%# Eval("DOB", "{0:dd/MM/yyyy}") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--     <asp:TemplateField HeaderText="Age">
                                        <ItemTemplate>
                                            <asp:Label ID="lblage" runat="server" Text='<%# Eval("Age")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--         <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Gmail">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGmail" runat="server" Text='<%# Eval("Gmail")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--     <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Appointment Reason">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappreason" runat="server" Text='<%# Eval("Appointment_Reason")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Appointment Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblapptype" runat="server" Text='<%# Eval("Appointment_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Appointment Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappdate" runat="server" Text='<%# Eval("Appoitment_Date", "{0:dd/MM/yyyy}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time Slot">
                                        <ItemTemplate>
                                            <asp:Label ID="lblapptimeslot" runat="server" Text='<%# Eval("Time_Slot")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact Reffrence">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappcotact" runat="server" Text='<%# Eval("Contact_Preferance")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblappstatus" runat="server" Text='<%# Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CommandArgument='<%# Eval("Appointment_Id")%>'>
                                             <img src="../icons/user_Edit.png" alt="Edit" width="25" height="25" />
                                            </asp:LinkButton>
                                            <%--  <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete1" CommandArgument='<%# Eval("Appointment_Id")%>'>
                                             <img src="../icons/delete.png" alt="Delete" width="25" height="25" />
                                            </asp:LinkButton>--%>
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


