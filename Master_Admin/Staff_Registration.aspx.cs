using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Staff_Registration : System.Web.UI.Page
{
    static String strcon = System.Configuration.ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
    SqlConnection con = new SqlConnection(strcon);
    SqlCommand cmd;
    BindDropdown B = new BindDropdown();
    protected void Page_Load(object sender, EventArgs e)
    {
        id.Text = ((Label)Master.FindControl("masterid")).Text;
        mastername.Text = ((Label)Master.FindControl("name")).Text;

        if (!IsPostBack)
        {
            B.bindRole(ddlrole);
            B.binDepartment(ddldepartment);
            if (Request.QueryString["StaffId"] != null && Request.QueryString["StaffId"] != String.Empty)
            {
                lblstaffid.Text = Request.QueryString["StaffId"];
                Bind();
                btnsubmit.Text = "Update";
                divuser.Visible = false;
                divpass.Visible = false;
                divcpass.Visible = false;
                chkbx.Visible = true;
                panfile.Attributes.Remove("required");

            }
        }
    }

    protected void AutoGenrate()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM [Staff] ORDER BY ID DESC", con);
            SqlDataReader reader = cmd.ExecuteReader();
            int latestNumericPart = 0001;

            // Check if there is a result
            if (reader.Read())
            {
                string latestId = reader["ID"].ToString();

                // Extract the numeric part from the ID
                string numericPart = latestId.Substring(2); // Assuming the prefix length is fixed at 2 characters
                latestNumericPart = int.Parse(numericPart);
            }

            reader.Close();

            // Increment the latest numeric part
            int newNumericPart = latestNumericPart + 1;

            // Format the new ID with the prefix M- followed by the incremented numeric part
            string formattedId = string.Format("S-{0:D4}", newNumericPart);
            lblid.Text = formattedId;


        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            con.Close();
        }
    }
    public void btnsubmit_OnClick(object sender, EventArgs e)
    {
        AutoGenrate();
        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO [dbo].[Staff]([ID],[Master_Id],[First_Name],[Middle_Name],[Last_Name],[Gender],[DOB],[Mobile],[Alternate_Mobile],[Gmail],[Role_Id],[Role],[Department_Id],[Department_Name],[Qualification],[Address],[Pan_No],[Pan_Card],[Photo],[Username],[Password],[Added_On],[Added_by_Id],[Added_By_Name]) VALUES(@ID,@Master_Id,@First_Name,@Middle_Name,@Last_Name,@Gender,@DOB,@Mobile,@Alternate_Mobile,@Gmail,@Role_Id,@Role,@Department_Id,@Department_Name,@Qualification,@Address,@Pan_No,@Pan_Card,@Photo,@Username,@Password,@Added_On,@Added_by_Id,@Added_By_Name)", con);
                cmd.Parameters.AddWithValue("@ID", lblid.Text);
                cmd.Parameters.AddWithValue("@Master_Id", id.Text);
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
                cmd.Parameters.AddWithValue("@Role_Id", ddlrole.SelectedValue);
                cmd.Parameters.AddWithValue("@Role", ddlrole.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Department_Id", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Department_Name", ddldepartment.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqualification.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Pan_No", txtpanno.Text);

                string f1 = "", f2 = "";
                string fileName = string.Empty;
                Random r = new Random();
                bool IsValidFile = false;
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
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        panfile.SaveAs(Server.MapPath("/Documents/Staff/PanCard/" + f1));
                        cmd.Parameters.AddWithValue("@Pan_Card", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Pan_Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Pan_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pan_Card", "");
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
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filephoto.SaveAs(Server.MapPath("/Documents/Staff/Photo/" + f2));
                        cmd.Parameters.AddWithValue("@Photo", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Pan_Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Photo", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Photo", "");
                }
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.Parameters.AddWithValue("@Added_by_Id", id.Text);
                cmd.Parameters.AddWithValue("@Added_By_Name", mastername.Text);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Registration successfully...!');", true);
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
                cmd = new SqlCommand("UPDATE [dbo].[Staff]SET [Master_Id] = @Master_Id ,[First_Name] = @First_Name ,[Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,[Gender] = @Gender ,[DOB] = @DOB ,[Mobile] = @Mobile ,[Alternate_Mobile] = @Alternate_Mobile ,[Gmail] = @Gmail ,[Role_Id]=@Role_Id,[Role] = @Role,[Department_Id]=@Department_Id,[Department_Name]=@Department_Name ,[Qualification] = @Qualification ,[Address] = @Address ,[Pan_No] = @Pan_No ,[Pan_Card] = @Pan_Card ,[Photo] = @Photo ,[Username] = @Username ,[Password] = @Password  WHERE Staff_Id=@Staff_Id", con);
                cmd.Parameters.AddWithValue("@Staff_Id", lblstaffid.Text);
                cmd.Parameters.AddWithValue("@Master_Id", id.Text);
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
                cmd.Parameters.AddWithValue("@Role_Id", ddlrole.SelectedValue);
                cmd.Parameters.AddWithValue("@Role", ddlrole.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Department_Id", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@Department_Name", ddldepartment.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Qualification", txtqualification.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Pan_No", txtpanno.Text);

                string f1 = "", f2 = "";
                string fileName = string.Empty;
                Random r = new Random();
                bool IsValidFile = false;
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
                    f1 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        panfile.SaveAs(Server.MapPath("/Documents/Staff/PanCard/" + f1));
                        cmd.Parameters.AddWithValue("@Pan_Card", f1);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Pan_Card File not valid');", true);
                        cmd.Parameters.AddWithValue("@Pan_Card", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Pan_Card", pancard.Text);
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
                    f2 = r.Next(1, 10000) + fileName;
                    if (IsValidFile)
                    {
                        filephoto.SaveAs(Server.MapPath("/Documents/Staff/Photo/" + f2));
                        cmd.Parameters.AddWithValue("@Photo", f2);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Staff Photo File not valid');", true);
                        cmd.Parameters.AddWithValue("@Photo", "");
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Photo", photo.Text);
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
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Staff Updated successfully...!'); if (confirmation) { window.location.href = 'View_Staff.aspx'; }", true); Clear();
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
        txtdob.Text = "";
        txtmobile.Text = "";
        txtaltmobile.Text = "";
        txtgmail.Text = "";
        ddlrole.ClearSelection();
        txtqualification.Text = "";
        txtaddress.Text = "";
        txtpanno.Text = "";
        txtusername.Text = "";
        txtpassword.Text = "";
    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Staff] where Staff_Id='" + lblstaffid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtfname.Text = dr["First_Name"].ToString();
            txtmname.Text = dr["Middle_Name"].ToString();
            txtlname.Text = dr["Last_Name"].ToString();
            ddlgender.SelectedValue = dr["Gender"].ToString();
            object dobObj = dr["DOB"];
            if (dobObj != DBNull.Value)
            {
                txtdob.Text = Convert.ToDateTime(dobObj).ToString("yyyy/MM/dd");
            }
            else
            {
                // If DOB is null, set the textbox to be empty
                txtdob.Text = string.Empty;
            }
            txtmobile.Text = dr["Mobile"].ToString();
            txtaltmobile.Text = dr["Alternate_Mobile"].ToString();
            txtgmail.Text = dr["Gmail"].ToString();
            ddlrole.SelectedValue = dr["Role"].ToString();
            txtqualification.Text = dr["Qualification"].ToString();
            txtaddress.Text = dr["Address"].ToString();
            txtpanno.Text = dr["Pan_No"].ToString();
            pancard.Text = dr["Pan_Card"].ToString();
            photo.Text = dr["Photo"].ToString();
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