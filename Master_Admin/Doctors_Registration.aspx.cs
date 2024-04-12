using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Doctors_Registration : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {
        id.Text = ((Label)Master.FindControl("masterid")).Text;
        mastername.Text = ((Label)Master.FindControl("name")).Text;
        if (!IsPostBack)
        {
            if (Request.QueryString["DoctorId"] != null && Request.QueryString["DoctorId"] != String.Empty)
            {
                lbldoctorid.Text = Request.QueryString["DoctorId"];
                Bind();
                btnsubmit.Text = "Update";
                divuser.Visible = false;
                divpass.Visible = false;
                divcpass.Visible = false;
                chkbx.Visible = true;
                fileaadhar.Attributes.Remove("required");
                panfile.Attributes.Remove("required");
            }
        }

    }

    protected void AutoGenrate()
    {
        using (SqlConnection con = new SqlConnection(strcon))
        {
            try
            {
                con.Open();
                string sql = "SELECT TOP 1 ID FROM [Doctors] ORDER BY ID DESC";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    object result = cmd.ExecuteScalar();
                    int latestNumericPart = 0;

                    if (result != null && result != DBNull.Value)
                    {
                        string latestId = result.ToString();
                        string numericPart = latestId.Substring(2); // Assuming the prefix length is fixed at 2 characters
                        if (int.TryParse(numericPart, out latestNumericPart))
                        {
                            latestNumericPart++; // Increment the latest numeric part
                        }
                        else
                        {
                            // Handle parsing failure
                        }
                    }
                    else
                    {
                        latestNumericPart = 1; // If no records found, start from 1
                    }

                    // Format the new ID with the prefix D- followed by the incremented numeric part
                    string formattedId = string.Format("D-{0:D4}", latestNumericPart);
                    lblid.Text = formattedId;
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception appropriately
                Console.WriteLine(ex.ToString());
            }
        }
    }


    public void btnsubmit_OnClick(object sender, EventArgs e)
    {
        AutoGenrate();
        string f1 = "", f2 = "", f3 = "", f4 = "", f5 = "", f6 = "";
        string fileName = string.Empty;
        Random r = new Random();
        bool IsValidFile = false;
        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO [dbo].[Doctors]([ID],[Master_Id],[Staff_Id],[First_Name],[Middle_Name],[Last_Name],[Gender],[DOB],[Mobile],[Alternate_Mobile],[Gmail],[Address],[Qualification],[Certificate1],[Certificate2],[Certificate3],[Specilization],[Experiance],[Pan_No],[Pan_Card],[Aadhar_No],[Aadhar_Card],[Photo],[Username],[Password],[Added_By_Id],[Added_By_Name],[Added_On]) VALUES(@ID,@Master_Id,@Staff_Id,@First_Name,@Middle_Name,@Last_Name,@Gender,@DOB,@Mobile,@Alternate_Mobile,@Gmail,@Address,@Qualification,@Certificate1,@Certificate2,@Certificate3,@Specilization,@Experiance,@Pan_No,@Pan_Card,@Aadhar_No,@Aadhar_Card,@Photo,@Username,@Password,@Added_By_Id,@Added_By_Name,@Added_On)", con);
                cmd.Parameters.AddWithValue("@ID", lblid.Text);
                cmd.Parameters.AddWithValue("@Master_Id", id.Text);
                cmd.Parameters.AddWithValue("@Staff_Id", "");
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                if (!txtdob.Text.Equals(""))
                {
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(txtdob.Text));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DOB", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqualification.Text);


                if (file1.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file1.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file1.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file1.SaveAs(Server.MapPath("/Documents/Doctor/Certificate1/" + f1));
                        cmd.Parameters.AddWithValue("@Certificate1", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate1 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate1", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate1", "");
                }

                if (file2.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file2.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file2.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file2.SaveAs(Server.MapPath("/Documents/Doctor/Certificate2/" + f2));
                        cmd.Parameters.AddWithValue("@Certificate2", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate2 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate2", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate2", "");
                }

                if (file3.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file3.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file3.FileName;
                    //f1 = ID + fileName;
                    f3 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file3.SaveAs(Server.MapPath("/Documents/Doctor/Certificate3/" + f3));
                        cmd.Parameters.AddWithValue("@Certificate3", f3);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate3 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate3", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate3", "");
                }

                cmd.Parameters.AddWithValue("@Specilization", txtspecilization.Text);
                cmd.Parameters.AddWithValue("@Experiance", txtexperiance.Text);

                cmd.Parameters.AddWithValue("@Pan_No", txtpanno.Text);

                if (panfile.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(panfile.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = panfile.FileName;
                    //f1 = ID + fileName;
                    f4 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        panfile.SaveAs(Server.MapPath("/Documents/Doctor/PanCard/" + f4));
                        cmd.Parameters.AddWithValue("@Pan_Card", f4);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Pan Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Pan_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pan_Card", "");
                }

                cmd.Parameters.AddWithValue("@Aadhar_No", txtaadhar.Text);

                if (fileaadhar.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(fileaadhar.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = fileaadhar.FileName;
                    //f1 = ID + fileName;
                    f5 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        fileaadhar.SaveAs(Server.MapPath("/Documents/Doctor/AadharCard/" + f5));
                        cmd.Parameters.AddWithValue("@Aadhar_Card", f5);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Aadhar Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Aadhar_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Aadhar_Card", "");
                }


                if (filephoto.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filephoto.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filephoto.FileName;
                    //f1 = ID + fileName;
                    f6 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filephoto.SaveAs(Server.MapPath("/Documents/Doctor/Photo/" + f6));
                        cmd.Parameters.AddWithValue("@Photo", f6);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Photo File not valid');", true);
                        cmd.Parameters.AddWithValue("@Photo", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Photo", "");
                }

                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@Added_by_Id", id.Text);
                cmd.Parameters.AddWithValue("@Added_By_Name", mastername.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctors Registration successfully...!');", true);
                Clear();
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
            }
        }
        else if (btnsubmit.Text == "Update")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE [dbo].[Doctors]SET [Master_Id] = @Master_Id ,[Staff_Id] = @Staff_Id ,[First_Name] = @First_Name ,[Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,[Gender] = @Gender ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Qualification] = @Qualification ,[Certificate1] = @Certificate1 ,[Certificate2] = @Certificate2 ,[Certificate3] = @Certificate3 ,[Specilization] = @Specilization ,[Experiance] = @Experiance ,[Pan_No] = @Pan_No ,[Pan_Card] = @Pan_Card ,[Aadhar_No] = @Aadhar_No ,[Aadhar_Card] = @Aadhar_Card ,[Photo] = @Photo ,[Username] = @Username ,[Password] = @Password  WHERE [Doctor_Id]=@Doctor_Id", con);
                cmd.Parameters.AddWithValue("@Doctor_Id", lbldoctorid.Text);
                cmd.Parameters.AddWithValue("@Master_Id", id.Text);
                cmd.Parameters.AddWithValue("@Staff_Id", "");
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);

                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Alternate_Mobile", txtaltmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqualification.Text);


                if (file1.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file1.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file1.FileName;
                    //f1 = ID + fileName;
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file1.SaveAs(Server.MapPath("/Documents/Doctor/Certificate1/" + f1));
                        cmd.Parameters.AddWithValue("@Certificate1", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate1 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate1", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate1", lblcertificate1.Text);
                }

                if (file2.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file2.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file2.FileName;
                    //f1 = ID + fileName;
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file2.SaveAs(Server.MapPath("/Documents/Doctor/Certificate2/" + f2));
                        cmd.Parameters.AddWithValue("@Certificate2", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate2 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate2", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate2", lblcertificate2.Text);
                }

                if (file3.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(file3.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = file3.FileName;
                    //f1 = ID + fileName;
                    f3 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        file3.SaveAs(Server.MapPath("/Documents/Doctor/Certificate3/" + f3));
                        cmd.Parameters.AddWithValue("@Certificate3", f3);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Certificate3 File not valid');", true);
                        cmd.Parameters.AddWithValue("@Certificate3", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Certificate3", lblcertificate3.Text);
                }

                cmd.Parameters.AddWithValue("@Specilization", txtspecilization.Text);
                cmd.Parameters.AddWithValue("@Experiance", txtexperiance.Text);

                cmd.Parameters.AddWithValue("@Pan_No", txtpanno.Text);

                if (panfile.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(panfile.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = panfile.FileName;
                    //f1 = ID + fileName;
                    f4 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        panfile.SaveAs(Server.MapPath("/Documents/Doctor/PanCard/" + f4));
                        cmd.Parameters.AddWithValue("@Pan_Card", f4);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Pan Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Pan_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pan_Card", lblpan.Text);
                }

                cmd.Parameters.AddWithValue("@Aadhar_No", txtaadhar.Text);

                if (fileaadhar.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(fileaadhar.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = fileaadhar.FileName;
                    //f1 = ID + fileName;
                    f5 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        fileaadhar.SaveAs(Server.MapPath("/Documents/Doctor/AadharCard/" + f5));
                        cmd.Parameters.AddWithValue("@Aadhar_Card", f5);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Aadhar Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Aadhar_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Aadhar_Card", lblaadhar.Text);
                }


                if (filephoto.HasFile)
                {
                    string[] validFileTypes = { ".bmp", ".gif", ".png", ".jpg", ".jpeg", ".pdf" };
                    string extension = System.IO.Path.GetExtension(filephoto.PostedFile.FileName);

                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (extension == validFileTypes[i])
                        {
                            IsValidFile = true;
                            break;
                        }
                    }
                    fileName = filephoto.FileName;
                    //f1 = ID + fileName;
                    f6 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filephoto.SaveAs(Server.MapPath("/Documents/Staff/Photo/" + f6));
                        cmd.Parameters.AddWithValue("@Photo", f6);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Doctor Photo File not valid');", true);
                        cmd.Parameters.AddWithValue("@Photo", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Photo", lblphoto.Text);
                }

                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                if (txtpassword.Text != "")
                {
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Password", lblpass.Text);
                }
                //cmd.Parameters.AddWithValue("@Added_by_Id", id.Text);
                //cmd.Parameters.AddWithValue("@Added_By_Name", mastername.Text);
                //cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Doctor Updated successfully...!'); if (confirmation) { window.location.href = 'View_Doctors.aspx'; }", true); Clear();
                Clear();
            }
            catch (Exception ex)
            {
                ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error Occard...!');", true);
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void Clear()
    {
        txtfname.Text = "";
        txtmname.Text = "";
        txtlname.Text = "";
        ddlgender.ClearSelection();
        txtmobile.Text = "";
        txtaltmobile.Text = "";
        txtgmail.Text = "";
        txtqualification.Text = "";
        txtaddress.Text = "";
        txtpanno.Text = "";
        txtusername.Text = "";
        txtpassword.Text = "";
        txtdob.Text = "";
        txtspecilization.Text = "";
        txtexperiance.Text = "";
        txtaadhar.Text = "";
    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Doctors] where Doctor_Id='" + lbldoctorid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtfname.Text = dr["First_Name"].ToString();
            txtmname.Text = dr["Middle_Name"].ToString();
            txtlname.Text = dr["Last_Name"].ToString();
            ddlgender.SelectedValue = dr["Gender"].ToString();
            txtmobile.Text = dr["Mobile"].ToString();
            txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
            txtgmail.Text = dr["Gmail"].ToString();
            txtaddress.Text = dr["Address"].ToString();
            txtqualification.Text = dr["Qualification"].ToString();
            lblcertificate1.Text = dr["Certificate1"].ToString();
            lblcertificate2.Text = dr["Certificate2"].ToString();
            lblcertificate3.Text = dr["Certificate3"].ToString();
            txtspecilization.Text = dr["Specilization"].ToString();
            txtexperiance.Text = dr["Experiance"].ToString();
            txtpanno.Text = dr["Pan_No"].ToString();
            lblpan.Text = dr["Pan_Card"].ToString();
            txtaadhar.Text = dr["Aadhar_No"].ToString();
            lblaadhar.Text = dr["Aadhar_Card"].ToString();
            lblphoto.Text = dr["Photo"].ToString();
            txtusername.Text = dr["Username"].ToString();
            lblpass.Text = dr["Password"].ToString();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con.Close();
        }
    }
    protected void ChckedChanged(object sender, EventArgs e)
    {
        if (chkupdate.Checked == true)
        {
            divuser.Visible = true;
            divpass.Visible = true;
            divcpass.Visible = true;
        }
        else
        {
            divuser.Visible = false;
            divpass.Visible = false;
            divcpass.Visible = false;
        }
    }
}