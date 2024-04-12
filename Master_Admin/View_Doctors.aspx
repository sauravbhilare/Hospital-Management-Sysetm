<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Admin/Master_Admin.master" AutoEventWireup="true" CodeFile="View_Doctors.aspx.cs" Inherits="Master_Admin_View_Doctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td, th {
            font-size: small;
        }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblid" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblphoto" runat="server" Visible="false"></asp:Label>
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <h3 class="card-title">View Doctors</h3>
                        <div class="table-responsive">
                            <asp:GridView ID="gvDoctor" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered zero-configuration"
                                ShowHeaderWhenEmpty="True" EmptyDataText="Sorry !! No Admin Found" EmptyDataRowStyle-ForeColor="Red"
                                EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-BackColor="White"
                                DataKeyNames="" AllowPaging="false" PageSize="20" BackColor="White" BorderColor="#DEDFDE"
                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                HorizontalAlign="Center" OnRowDeleting="gvDoctor_RowDeleting" OnRowCommand="gvDoctor_RowCommand"
                                OnRowUpdating="gvDoctor_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="Doctor Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMasterId" runat="server" Text='<%# Eval("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%# String.Concat(Eval("First_Name")," ",Eval("Middle_Name")," ",Eval("Last_Name"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="Qualification">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Specilization">
                                        <ItemTemplate>
                                            <asp:Label ID="lblspecilization" runat="server" Text='<%# Eval("Specilization")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Experience">
                                        <ItemTemplate>
                                            <asp:Label ID="lblExperiance" runat="server" Text='<%# Eval("Experiance")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--     <asp:TemplateField HeaderText="Pan No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpan" runat="server" Text='<%# Eval("Pan_No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%--  <asp:TemplateField HeaderText="Pan Card">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypDownloadPanCard" runat="server" Visible='<%# !string.IsNullOrEmpty(Eval("Pan_Card").ToString()) %>' NavigateUrl='<%# ResolveUrl("/Documents/Doctor/PanCard/" + Eval("Pan_Card")) %>' Target="_blank" Download='<%# "Pan_Card_" + Eval("Pan_Card") %>'>
                                           <i class="fa fa-download"></i>
                                            </asp:HyperLink>
                                            <asp:Label ID="lblPanCardNotAvailable" runat="server" Visible='<%# string.IsNullOrEmpty(Eval("Pan_Card").ToString()) %>'>
                                          Not available
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--  <asp:TemplateField HeaderText="Aadhar No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblaadhar" runat="server" Text='<%# Eval("Aadhar_No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <%-- <asp:TemplateField HeaderText="Aadhar Card">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypDownload" runat="server" Visible='<%# !string.IsNullOrEmpty(Eval("Aadhar_Card").ToString()) %>' NavigateUrl='<%# ResolveUrl("/Documents/Doctor/AadharCard/" + Eval("Aadhar_Card")) %>' Target="_blank" Download='<%# "Aadhar_Card_" + Eval("Aadhar_Card") %>'>
                                            <i class="fa fa-download"></i>
                                            </asp:HyperLink>
                                            <asp:Label ID="lblNotAvailable" runat="server" Visible='<%# string.IsNullOrEmpty(Eval("Aadhar_Card").ToString()) %>'>
                                          Not available
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--   <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <%--  <asp:TemplateField HeaderText="Photo">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hypDownloadPhoto" runat="server" Visible='<%# !string.IsNullOrEmpty(Eval("Photo").ToString()) %>' NavigateUrl='<%# ResolveUrl("/Documents/Staff/Photo/" + Eval("Photo")) %>' Target="_blank" Download='<%# "Photo_" + Eval("Photo") %>'>
                                               <i class="fa fa-download"></i>
                                            </asp:HyperLink>
                                            <asp:Label ID="lblPhotoNotAvailable" runat="server" Visible='<%# string.IsNullOrEmpty(Eval("Photo").ToString()) %>'>
                                             Not available
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>



                                    <asp:TemplateField HeaderText="Opration">
                                        <ItemTemplate>
                                            <div class="dropdown custom-dropdown">
                                                <div data-toggle="dropdown"><i class="fa fa-ellipsis-v"></i></div>
                                                <div class="dropdown-menu dropdown-menu-left" style="width: 140px">
                                                    <asp:LinkButton ID="LinkButton1" runat="server" Style="font-size: 16px;" Text="&nbsp;View" class="fa fa-eye dropdown-item" CommandName="View" CommandArgument='<%# Eval("Doctor_Id")%>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkUpdate" runat="server" Style="font-size: 16px;" Text="&nbsp;Edit" class="fa fa-edit dropdown-item" CommandName="Update" CommandArgument='<%# Eval("Doctor_Id")%>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" Style="font-size: 16px;" Text="&nbsp;Delete" class="fa fa-trash dropdown-item" CommandName="Delete1" CommandArgument='<%# Eval("Doctor_Id")%>'></asp:LinkButton>

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
                    <h5 class="modal-title">View Doctor Details</h5>
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
                                    <h3 class="widget-title">Doctor Details</h3>
                                    <div class="row no-mp">
                                        <div class="col-md-4">
                                            <div class="card mb-4">
                                                <asp:Image ID="imgDoctorPhoto" runat="server" CssClass="card-img-top" AlternateText="DOCTOR" />
                                                <div class="card-body">
                                                    <h4 class="card-title" style="text-align: center;">
                                                        <asp:Label ID="lbldoctorname" runat="server"></asp:Label>
                                                    </h4>
                                                    <p class="card-text">
                                                    </p>
                                                    <%--    <button type="button" class="btn btn-success mb-2">
                                                        <span class="ti-pencil-alt"></span>Edit

                                                    </button>
                                                    <button type="button" class="btn btn-danger">
                                                        <span class="ti-trash"></span>Delete</button>--%>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="table-responsive">
                                                <table class="table header-border table-hover verticle-middle">
                                                    <tbody>
                                                        <tr>
                                                            <td><strong>Specialization</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblspecil" runat="server">Specialization</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Experience</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblexp" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Gender</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblgender" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Address</strong></td>
                                                            <td>
                                                                <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Mobile</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblmobile" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Date Of Birth</strong> </td>
                                                            <td>
                                                                <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Email</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblemail" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Qualification</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblqualification" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Cirtificate</strong></td>
                                                            <td>

                                                                <asp:Label ID="lblcer" runat="server" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkcer" runat="server" OnClick="lnkcer_Click" Visible="false"><i class="fa fa-download"></i></asp:LinkButton>


                                                                <asp:Label ID="lblcer1" runat="server" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkcer1" runat="server" OnClick="lnkcer1_Click" Visible="false"><i class="fa fa-download"></i></asp:LinkButton>


                                                                <asp:Label ID="lblcer2" runat="server" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkcer2" runat="server" OnClick="lnkcer2_Click" Visible="false"><i class="fa fa-download"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Pan</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblpancard" runat="server"></asp:Label>
                                                                <asp:Label ID="lblpanfile" runat="server" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkpan" runat="server" OnClick="lnkpan_Click" Visible="false"><i class="fa fa-download"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><strong>Aadhar</strong></td>
                                                            <td>
                                                                <asp:Label ID="lblaadharcard" runat="server">12th</asp:Label>
                                                                <asp:Label ID="lblafile" runat="server" Visible="false"></asp:Label>
                                                                <asp:LinkButton ID="lnkafile" runat="server" OnClick="lnkafile_Click" Visible="false"><i class="fa fa-download"></i></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
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
</asp:Content>

