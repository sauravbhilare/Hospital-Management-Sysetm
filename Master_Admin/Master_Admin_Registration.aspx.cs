using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_Admin_Staff_Registration : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["MasterId"] != null && Request.QueryString["MasterId"] != String.Empty)
            {
                lblid.Text = Request.QueryString["MasterId"];
                Bind();
                btnsubmit.Text = "Update";
                divuser.Visible = false;
                divpass.Visible = false;
                divcpass.Visible = false;
                chkbx.Visible = true;

            }
        }
    }

    protected void AutoGenrate()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 ID FROM Master_Admin ORDER BY ID DESC", con);
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
            string formattedId = string.Format("M-{0:D4}", newNumericPart);
            lblmasterid.Text = formattedId;


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
        SqlConnection con = new SqlConnection(strcon);
        AutoGenrate();
        if (btnsubmit.Text == "Submit")
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO[dbo].[Master_Admin]([ID],[First_Name],[Middle_Name],[Last_Name],[Gender],[Mobile],[Gmail],[Address],[Username],[Password],[Role],[Added_On]) VALUES(@ID,@First_Name, @Middle_Name, @Last_Name, @Gender, @Mobile, @Gmail, @Address, @Username, @Password,@Role,@Added_On)", con);
                cmd.Parameters.AddWithValue("@ID", lblmasterid.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@Role", "Master Admin");
                cmd.Parameters.AddWithValue("@Added_On", DateTime.Now);
                cmd.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Master Admin Registration successfully...!');", true);
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
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Master_Admin]SET [First_Name] = @First_Name ,[Middle_Name] = @Middle_Name ,[Last_Name] = @Last_Name ,[Gender] = @Gender ,[Mobile] = @Mobile ,[Gmail] = @Gmail ,[Address] = @Address ,[Username] = @Username ,[Password] = @Password WHERE Master_Id=@Master_Id", con);
                cmd.Parameters.AddWithValue("@Master_Id", lblid.Text);
                cmd.Parameters.AddWithValue("@First_Name", txtfname.Text);
                cmd.Parameters.AddWithValue("@Middle_Name", txtmname.Text);
                cmd.Parameters.AddWithValue("@Last_Name", txtlname.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.SelectedValue);
                cmd.Parameters.AddWithValue("@Mobile", txtmobile.Text);
                cmd.Parameters.AddWithValue("@Gmail", txtgmail.Text);
                cmd.Parameters.AddWithValue("@Address", txtaddress.Text);
                cmd.Parameters.AddWithValue("@Username", txtusername.Text);
                if (txtpassword.Text != "")
                {
                    cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Password", lblpass.Text);
                }
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "var confirmation = confirm('Master Admin Updated successfully...!'); if (confirmation) { window.location.href = 'View_MasterAdmin.aspx'; }", true); Clear();
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
        txtgmail.Text = "";
        txtaddress.Text = "";
        txtusername.Text = "";
        txtpassword.Text = "";
    }
    protected void Bind()
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * From [dbo].[Master_Admin] where Master_Id='" + lblid.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            txtfname.Text = dr["First_Name"].ToString();
            txtmname.Text = dr["Middle_Name"].ToString();
            txtlname.Text = dr["Last_Name"].ToString();
            ddlgender.SelectedValue = dr["Gender"].ToString();
            txtmobile.Text = dr["Mobile"].ToString();
            txtgmail.Text = dr["Gmail"].ToString();
            txtaddress.Text = dr["Address"].ToString();
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