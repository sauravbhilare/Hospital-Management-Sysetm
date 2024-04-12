using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        try
        {
            con.Open();

            if (ddlrole.SelectedValue == "Master Admin")
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[Master_Admin] where  Username='" + txtusername.Text + "' and Password='" + txtpass.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (txtusername.Text.Equals(dr["Username"].ToString(), StringComparison.OrdinalIgnoreCase) && txtpass.Text == dr["Password"].ToString())
                        {

                            // Store values in cookies
                            Response.Cookies["Master_Id"].Value = dr["Master_Id"].ToString();
                            Response.Cookies["First_Name_Last_Name"].Value = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                            // Set expiration for the cookies (if needed)
                            Response.Cookies["Master_Id"].Expires = DateTime.Now.AddHours(1); // Example: expires in 1 hour
                            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddHours(1);
                            Response.Redirect("Master_Admin/Dashboard.aspx", true);


                        }
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credential...!');", true);
                }
            }
            if (ddlrole.SelectedValue == "Admin")
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[Staff] where  Username='" + txtusername.Text + "' and Password='" + txtpass.Text + "' and Role=@Role", con);
                cmd.Parameters.AddWithValue("@Role", "Admin");
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (txtusername.Text.Equals(dr["Username"].ToString(), StringComparison.OrdinalIgnoreCase) && txtpass.Text == dr["Password"].ToString())
                        {

                            // Store values in cookies
                            Response.Cookies["Staff_Id"].Value = dr["Staff_Id"].ToString();
                            Response.Cookies["First_Name_Last_Name"].Value = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                            Response.Cookies["Role"].Value = dr["Role"].ToString();
                            // Set expiration for the cookies (if needed)
                            Response.Cookies["Staff_Id"].Expires = DateTime.Now.AddHours(1); // Example: expires in 1 hour
                            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddHours(1);
                            Response.Redirect("Staff/Dashboard.aspx", true);


                        }
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credential...!');", true);
                }
            }
            if (ddlrole.SelectedValue == "Staff")
            {
                SqlCommand cmd = new SqlCommand("Select * from [dbo].[Staff] where  Username='" + txtusername.Text + "' and Password='" + txtpass.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (txtusername.Text.Equals(dr["Username"].ToString(), StringComparison.OrdinalIgnoreCase) && txtpass.Text == dr["Password"].ToString())
                        {

                            // Store values in cookies
                            Response.Cookies["Staff_Id"].Value = dr["Staff_Id"].ToString();
                            Response.Cookies["First_Name_Last_Name"].Value = dr["First_Name"].ToString() + " " + dr["Last_Name"].ToString();
                            Response.Cookies["Role"].Value = dr["Role"].ToString();
                            // Set expiration for the cookies (if needed)
                            Response.Cookies["Staff_Id"].Expires = DateTime.Now.AddHours(1); // Example: expires in 1 hour
                            Response.Cookies["First_Name_Last_Name"].Expires = DateTime.Now.AddHours(1);
                            Response.Redirect("Staff/Dashboard1.aspx", true);


                        }
                    }

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid Credential...!');", true);
                }
            }
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
}